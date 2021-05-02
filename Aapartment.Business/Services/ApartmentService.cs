using Aapartment.Business.Dto;
using Aapartment.Business.Exceptions;
using Aapartment.Business.Config;
using Aapartment.Dal;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Aapartment.Dal.Entities;
using Aapartment.Business.ServiceInterfaces;

namespace Aapartment.Business.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;

        public ApartmentService(AapartmentDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }

        public async Task<ApartmentDto> GetByIdAsync(int id)
        {
            var apartment = await db.Apartments.Where(a => a.Id == id).Include(x => x.Services).Include(r => r.Rooms).FirstOrDefaultAsync();
            if (apartment == null) throw new DbNullException();
            return mapper.Map<ApartmentDto>(apartment);
        }

        public async Task<int> GetPageCounts(int pagesize)
        {
            var apartments = await db.Apartments.ToListAsync();
            var totalPages = (int)Math.Ceiling((decimal)apartments.Count / (decimal)pagesize);
            return totalPages;
        }

        public async Task<int> GetAverageCountByApartmentId(int apartmentid)
        {
            var reviews = await db.Reviews.Where(b => b.ApartmentId == apartmentid).ToListAsync();
            if (reviews.Count() != 0)
                return reviews.Sum(e => e.Stars) / reviews.Count();
            else
                return 0;
        }

        public async Task<PagedResult<ApartmentDto>> GetAllPagedAsync(int pagesize, int pagenumber, List<string> filters)
        {
            if (pagenumber <= 0 || pagesize <= 0) throw new QueryParamsNullException();

            IEnumerable<ApartmentDto> apartments = Enumerable.Empty<ApartmentDto>();
            IEnumerable<Apartment> apartmentsFiltered = Enumerable.Empty<Apartment>();

            Func<Apartment, bool> filter =  apartment =>
            {
                foreach (string filt in filters)
                {
                    if (apartment.Name.ToLower().Contains(filt.ToLower())) return true;

                }
                return false;
            };

            if (filters.Count() != 0 && filters!=null)
            {
                apartmentsFiltered = db.Apartments.Where(filter)
                                            .OrderBy(a => a.Name);
                apartments = apartmentsFiltered
                                            .Skip(pagesize * (pagenumber - 1))
                                            .Take(pagesize)
                                            .Select(r =>  mapper.Map<ApartmentDto>(r))
                                            .AsEnumerable();
            } else
            {
                apartments = await db.Apartments.OrderBy(a => a.Name)
                                               .Paging(pagesize, pagenumber)
                                               .Select(r => mapper.Map<ApartmentDto>(r))
                                               .ToListAsync();
            }

            var apartmentslistWithRating = apartments.ToList();
            foreach (var a in apartmentslistWithRating)
            {
                a.Ratings = await GetAverageCountByApartmentId(a.Id);
            }


            PagedResult<ApartmentDto> result = new PagedResult<ApartmentDto>();
            result.Results = apartmentslistWithRating;
            result.PageSize = pagesize;
            result.PageNumber = pagenumber;
            if (filters.Count() == 0)
                result.AllResultsCount = await db.Apartments.CountAsync();
            else
                result.AllResultsCount = apartmentsFiltered.Count();
            return result;
        }

        public async Task<IEnumerable<ApartmentDto>> GetRecommendation(int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) throw new QueryParamsNullException();
            var apartments = await db.Apartments.OrderByDescending(a => a.Reviews.Average(b => b.Stars)).Paging(pagesize, pagenumber).ToListAsync();
            var dtoApartments= mapper.Map<List<ApartmentDto>>(apartments);
            for(int i = 0; i < dtoApartments.Count(); i++)
            {
                dtoApartments[i].Ratings = await GetAverageCountByApartmentId(apartments[i].Id);
            }
            return dtoApartments;
        }

        public async Task<ApartmentDto> CreateAsync(ApartmentDto apartmentDto)
        {
            if (CheckIfValid(apartmentDto))
            {
                var apartment = mapper.Map<Apartment>(apartmentDto);
                var result = db.Apartments.Add(apartment);
                await db.SaveChangesAsync();
                return mapper.Map<ApartmentDto>(result.Entity);
            }
            else throw new QueryParamsNullException();
        }

        public async Task DeleteAsync(int id)
        {
            var apartment = await db.Apartments.Where(a => a.Id == id).Include(e => e.Reviews).Include(e => e.Rooms).ThenInclude(e => e.Bookings).FirstOrDefaultAsync();
            if (apartment == null) throw new DbNullException();

            using (var transaction = db.Database.BeginTransaction())
            {
                foreach(var room in apartment.Rooms)
                {
                    foreach(var booking in room.Bookings)
                    {
                        db.Bookings.Remove(booking);
                    }
                    db.Rooms.Remove(room);
                }
                
                foreach(var review in apartment.Reviews)
                {
                    db.Reviews.Remove(review);
                }

                db.Apartments.Remove(apartment);

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            
            
        }

        public async Task<ApartmentDto> ModifyAsync(int id, ApartmentDto apartmentDto)
        {
            if (CheckIfValid(apartmentDto))
            {
                var apartment = await db.Apartments.Where(a => a.Id == id).FirstOrDefaultAsync();
                if (apartment == null) throw new DbNullException();
                apartment.Services = new List<Service>(apartmentDto.Services);
                apartment.Name = apartmentDto.Name;
                apartment.Address = apartmentDto.Address;
                apartment.Description = apartmentDto.Description;
                apartment.ImageName = apartmentDto.ImageName;
                await db.SaveChangesAsync();
                return mapper.Map<ApartmentDto>(apartment);
            }
            else throw new QueryParamsNullException();
        }

        public bool CheckIfValid(ApartmentDto apartment)
        {
            if (string.IsNullOrEmpty(apartment.Name)) return false;
            if (string.IsNullOrEmpty(apartment.ImageName)) return false;
            if (apartment.Address == null) return false;
            else
            {
                if (string.IsNullOrEmpty(apartment.Address.City)) return false;
                if (string.IsNullOrEmpty(apartment.Address.Country)) return false;
                if (string.IsNullOrEmpty(apartment.Address.Street)) return false;
                if (apartment.Address.ZipCode <= 0) return false;
            }
            return true;
        }
    }
}
