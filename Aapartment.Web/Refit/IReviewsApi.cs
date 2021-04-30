using Aapartment.Business.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Refit
{
    public interface IReviewsApi
    {
        [Get("/aid/{apartmenid}")]
        Task<IEnumerable<ReviewDto>> GetAllByApartmentId(int apartmenid, [Query] int size, [Query] int page);

        [Post("")]
        Task<ReviewDto> Create([Body] ReviewDto reviewDto);

        [Delete("/{id}")]
        Task Delete(int id);


    }
}
