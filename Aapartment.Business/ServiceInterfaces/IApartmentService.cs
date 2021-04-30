using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aapartment.Business.ServiceInterfaces
{
    public interface IApartmentService
    {
        Task<ApartmentDto> GetByIdAsync(int id);
        Task<int> GetPageCounts(int pagesize);
        Task<PagedResult<ApartmentDto>> GetAllPagedAsync(int pagesize, int pagenumber, List<string> filters);
        Task<IEnumerable<ApartmentDto>> GetRecommendation(int pagesize, int pagenumber);
        Task<ApartmentDto> CreateAsync(ApartmentDto apartmentDto);
        Task DeleteAsync(int id);
        Task<ApartmentDto> ModifyAsync(int id, ApartmentDto apartmentDto);

    }
}
