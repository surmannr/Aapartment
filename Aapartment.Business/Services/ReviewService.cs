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
using Aapartment.Business.Logger;

namespace Aapartment.Business.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public ReviewService(AapartmentDbContext _db, IMapper _mapper, ILoggerManager logger)
        {
            db = _db;
            mapper = _mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllPagedByApartmentIdAsync(int apartmentid, int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0)
            {
                logger.LogError($"Error: paging failed - pagenumber: {pagenumber} && pagesize: {pagesize}");
                throw new QueryParamsNullException();
            }
            var reviews = await db.Reviews.Where(b => b.ApartmentId == apartmentid).Include(r => r.User).OrderBy(a => a.Created).Paging(pagesize, pagenumber).ToListAsync();
            var reviewDtos = mapper.Map<List<ReviewDto>>(reviews);
            foreach(var r in reviewDtos)
            {
                var user = await db.Users.Where(u => u.Id == r.UserId).FirstOrDefaultAsync();
                if (user != null)
                {
                    r.Name = user.FirstName + " " + user.LastName;
                }
                else {
                    logger.LogError($"The user doesn't exist for {r.Id} review");
                    throw new DbNullException();
                } 
            }
            return reviewDtos;
        }

        public async Task<ReviewDto> CreateAsync(ReviewDto reviewDto)
        {
            if (CheckIfValid(reviewDto))
            {
                var apartment = await db.Apartments.Where(e => e.Id == reviewDto.ApartmentId).FirstOrDefaultAsync();
                if (apartment == null)
                {
                    logger.LogError($"Validation failed for creating review.");
                    throw new QueryParamsNullException("Nem létezik az értékeléshez tartozó szálloda.");
                }

                var user = await db.Users.Where(e => e.Id == reviewDto.UserId).FirstOrDefaultAsync();
                if (user == null)
                {
                    logger.LogError($"Validation failed for creating review.");
                    throw new QueryParamsNullException("Nem létezik az értékeléshez tartozó felhasználó.");
                }

                var review = mapper.Map<Review>(reviewDto);
                var result = db.Reviews.Add(review);
                await db.SaveChangesAsync();
                return mapper.Map<ReviewDto>(result.Entity);

            }
            else {
                logger.LogError($"Validation failed for creating review.");
                throw new QueryParamsNullException();
            } 
        }

        public async Task DeleteAsync(int id)
        {
            var review = await db.Reviews.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (review == null) {
                logger.LogError($"Error: review with id:{id} does not exist.");
                throw new DbNullException();
            } 
            db.Reviews.Remove(review);
            await db.SaveChangesAsync();
        }


        public bool CheckIfValid(ReviewDto reviewDto)
        {
            if (reviewDto.ApartmentId < 0) return false;
            if (reviewDto.UserId < 0) return false;
            if (reviewDto.Stars < 1 || reviewDto.Stars > 5) return false;
            if (string.IsNullOrEmpty(reviewDto.Content)) return false;
            return true;
        }
    }
}
