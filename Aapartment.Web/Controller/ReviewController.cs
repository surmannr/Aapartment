using Aapartment.Business.Dto;
using Aapartment.Business.ServiceInterfaces;
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

        public ReviewController(IReviewService _reviewService)
        {
            reviewService = _reviewService;
        }

        [HttpGet]
        [Route("aid/{apartmenid}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllByApartmentId(int apartmenid,[FromQuery] int size, [FromQuery] int page)
        {
            var bookings = await reviewService.GetAllPagedByApartmentIdAsync(apartmenid,size, page);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> Create([FromBody] ReviewDto reviewDto)
        {
            var booking = await reviewService.CreateAsync(reviewDto);
            return Ok(booking);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await reviewService.DeleteAsync(id);
            return Ok();
        }
    }
}
