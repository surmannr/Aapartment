using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Aapartment.Business.Logger;
using Aapartment.Business.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILoggerManager logger;

        public BookingController(IBookingService _bookingService, ILoggerManager logger)
        {
            bookingService = _bookingService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BookingDto>> GetById(int id)
        {
            var booking = await bookingService.GetByIdAsync(id);
            logger.LogInfo($"Get booking by id:{id} successfully.");
            return Ok(booking);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<BookingDto>>> GetAll([FromQuery]int size, [FromQuery] int page)
        {
            var bookings = await bookingService.GetAllPagedAsync(size, page);
            logger.LogInfo($"Get all bookings successfully.");
            return Ok(bookings);
        }

        [HttpGet]
        [Route("user/{userid}")]
        public async Task<ActionResult<PagedResult<BookingDto>>> GetAllByUserId([FromQuery] int size, [FromQuery] int page, int userid)
        {
            var bookings = await bookingService.GetAllPagedByUserIdAsync(userid,size, page);
            logger.LogInfo($"Get bookings by userid:{userid} successfully.");
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> Create([FromBody] BookingDto bookingDto)
        {
            var booking = await bookingService.CreateAsync(bookingDto);
            logger.LogInfo($"Create a new booking successfully.");
            return Ok(booking);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await bookingService.DeleteAsync(id);
            logger.LogInfo($"Delete booking by id:{id} successfully.");
            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<BookingDto>> ModifyStatus([FromQuery]bool ispaid, int id)
        {
            var booking = await bookingService.ModifyStatusAsync(id, ispaid);
            logger.LogInfo($"Modify booking status by id:{id} successfully.");
            return Ok(booking);
        }

    }
}
