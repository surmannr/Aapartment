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
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;
        private readonly ILoggerManager logger;

        public ReviewController(IReviewService _reviewService, ILoggerManager logger)
        {
            reviewService = _reviewService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("aid/{apartmenid}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllByApartmentId(int apartmenid,[FromQuery] int size, [FromQuery] int page)
        {
            var bookings = await reviewService.GetAllPagedByApartmentIdAsync(apartmenid,size, page);
            logger.LogInfo($"Get review by apartmentid:{apartmenid} successfully.");
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> Create([FromBody] ReviewDto reviewDto)
        {
            var booking = await reviewService.CreateAsync(reviewDto);
            logger.LogInfo($"Create a new review successfully.");
            return Ok(booking);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await reviewService.DeleteAsync(id);
            logger.LogInfo($"Delete review successfully.");
            return Ok();
        }
    }
}
