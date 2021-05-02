using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Refit
{
    public interface IBookingApi
    {
        [Get("/{id}")]
        Task<BookingDto> GetById(int id);

        [Get("")]
        Task<IEnumerable<BookingDto>> GetAll([Query] int size, [Query] int page);

        [Get("/user/{userid}")]
        Task<PagedResult<BookingDto>> GetAllByUserId([Query] int size, [Query] int page, int userid);

        [Post("")]
        Task<BookingDto> Create([Body] BookingDto bookingDto);

        [Delete("/{id}")]
        Task Delete(int id);

        [Patch("/{id}")]
        Task<BookingDto> ModifyStatus([Query] bool ispaid, int id);
    }
}
