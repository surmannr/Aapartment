using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Refit
{
    public interface IApartmentsApi
    {
        [Get("")]
        Task<PagedResult<ApartmentDto>> GetAll([Query("pageSize")] int pageSize, [Query("pageNumber")] int pageNumber, [Body] List<string>filters);
        
        
        [Get("/pagecount")]
        Task<int> GetPageCount([Query] int size);

        [Get("/recommendation")]
        Task<IEnumerable<ApartmentDto>> GetRecommendation([Query] int size, [Query] int page);

        [Get("/{id}")]
        Task<ApartmentDto> GetById(int id);

        [Post("")]
        Task<ApartmentDto> Create([Body] ApartmentDto apartmentDto);

        [Delete("/{id}")]
        Task Delete(int id);

        [Put("/{id}")]
        Task<ApartmentDto> Modify(int id, [Body] ApartmentDto apartmentDto);
    }
}
