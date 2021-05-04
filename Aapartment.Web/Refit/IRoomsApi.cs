using Aapartment.Business.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Refit
{
    public interface IRoomsApi
    {
        [Get("")]
        Task<IEnumerable<RoomDto>> GetAll([Query] int size, [Query] int page);

        [Get("/all")]
        Task<IEnumerable<RoomDto>> GetAllWithoutPagingByApartmentId([Query] int apartmentid);

        [Get("/aid/{id}")]
        Task<IEnumerable<RoomDto>> GetAllByApartmentId(int id, [Query] int size, [Query] int page);

        [Get("/aid/{id}/count")]
        Task<int> GetAllByApartmentIdCount(int id);

        [Post("")]
        Task<RoomDto> Create([Body] RoomDto roomDto);

        [Delete("/{id}")]
        Task Delete(int id);

        [Put("/{id}")]
        Task<RoomDto> Modify(int id, [Body] RoomDto roomDto);

        [Patch("/{id}/available")]
        Task<RoomDto> ModifyAvailable(int id, [Query] bool available);


    }
}
