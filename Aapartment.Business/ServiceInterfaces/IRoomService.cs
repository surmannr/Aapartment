using Aapartment.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aapartment.Business.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllPagedAsync(int pagesize, int pagenumber);
        Task<IEnumerable<RoomDto>> GetAllPagedByApartmentIdAsync(int apartmentid, int pagesize, int pagenumber);
        Task<IEnumerable<RoomDto>> GetAllByApartmentIdAsync(int apartmentid);
        Task<int> GetAllCountByApartmentId(int apartmentid);
        Task<RoomDto> CreateAsync(RoomDto roomDto);
        Task DeleteAsync(int id);
        Task<RoomDto> ModifyAsync(int id, RoomDto roomDto);
        Task<RoomDto> ModifyAvailableAsync(int id, bool available);
    }
}
