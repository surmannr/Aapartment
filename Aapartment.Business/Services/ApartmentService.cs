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
            var apartment = await db.Apartments.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (apartment == null) throw new DbNullException();
            return mapper.Map<ApartmentDto>(apartment);
        }

        public async Task<IEnumerable<ApartmentDto>> GetAllPagedAsync(int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) throw new QueryParamsNullException();
            var apartments = await db.Apartments.Paging(pagesize,pagenumber,a => a.Name).ToListAsync();
            return mapper.Map<List<ApartmentDto>>(apartments);
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
            var apartment = await db.Apartments.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (apartment == null) throw new DbNullException();
            db.Apartments.Remove(apartment);
            await db.SaveChangesAsync();
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
