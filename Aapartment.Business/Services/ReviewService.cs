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
    public class ReviewService : IReviewService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;

        public ReviewService(AapartmentDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllPagedByApartmentIdAsync(int apartmentid, int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) throw new QueryParamsNullException();
            var reviews = await db.Reviews.Where(b => b.ApartmentId == apartmentid).OrderBy(a => a.Created).Paging(pagesize, pagenumber).ToListAsync();
            return mapper.Map<List<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> CreateAsync(ReviewDto reviewDto)
        {
            if (CheckIfValid(reviewDto))
            {
                var apartment = await db.Apartments.Where(e => e.Id == reviewDto.ApartmentId).FirstOrDefaultAsync();
                if (apartment == null) throw new QueryParamsNullException("Nem létezik az értékeléshez tartozó szálloda.");

                var user = await db.Users.Where(e => e.Id == reviewDto.UserId).FirstOrDefaultAsync();
                if (user == null) throw new QueryParamsNullException("Nem létezik az értékeléshez tartozó felhasználó.");

                var review = mapper.Map<Review>(reviewDto);
                var result = db.Reviews.Add(review);
                await db.SaveChangesAsync();
                return mapper.Map<ReviewDto>(result.Entity);

            }
            else throw new QueryParamsNullException();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await db.Reviews.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (review == null) throw new DbNullException();
            db.Reviews.Remove(review);
            await db.SaveChangesAsync();
        }


        public bool CheckIfValid(ReviewDto reviewDto)
        {
            if (reviewDto.Created < DateTime.Now) return false;
            if (reviewDto.ApartmentId < 0) return false;
            if (reviewDto.UserId < 0) return false;
            if (reviewDto.Stars < 1 || reviewDto.Stars > 5) return false;
            if (string.IsNullOrEmpty(reviewDto.Content)) return false;
            return true;
        }
    }
}
