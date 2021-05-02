using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aapartment.Business.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<BookingDto> GetByIdAsync(int id);
        Task<PagedResult<BookingDto>> GetAllPagedByUserIdAsync(int userid, int pagesize, int pagenumber);
        Task<IEnumerable<BookingDto>> GetAllPagedAsync(int pagesize, int pagenumber);
        Task<BookingDto> CreateAsync(BookingDto bookingDto);
        Task DeleteAsync(int id);
        Task<BookingDto> ModifyStatusAsync(int id, bool paid);
    }
}
