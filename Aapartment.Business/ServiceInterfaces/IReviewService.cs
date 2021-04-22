using Aapartment.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aapartment.Business.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllPagedByApartmentIdAsync(int apartmentid, int pagesize, int pagenumber);
        Task<ReviewDto> CreateAsync(ReviewDto reviewDto);
        Task DeleteAsync(int id);
    }
}
