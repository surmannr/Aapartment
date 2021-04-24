using Aapartment.Business.Dto;
using Aapartment.Business.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Controller
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BookingDto>> GetById(int id)
        {
            var booking = await bookingService.GetByIdAsync(id);
            return Ok(booking);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAll([FromQuery]int size, [FromQuery] int page)
        {
            var bookings = await bookingService.GetAllPagedAsync(size, page);
            return Ok(bookings);
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllByUserId([FromQuery] int size, [FromQuery] int page, int userid)
        {
            var bookings = await bookingService.GetAllPagedByUserIdAsync(userid,size, page);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> Create([FromBody] BookingDto bookingDto)
        {
            var booking = await bookingService.CreateAsync(bookingDto);
            return Ok(booking);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await bookingService.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<BookingDto>> ModifyStatus([FromQuery]bool ispaid, int id)
        {
            var booking = await bookingService.ModifyStatusAsync(id, ispaid);
            return Ok(booking);
        }

    }
}
