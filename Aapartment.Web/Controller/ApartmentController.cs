using Aapartment.Business.Dto;
using Aapartment.Business.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Controller
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService apartmentService;

        public ApartmentController(IApartmentService _apartmentService)
        {
            apartmentService = _apartmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetAll([FromQuery]int size, [FromQuery] int page)
        {
            var apartmentlist = await apartmentService.GetAllPagedAsync(size, page);
            return Ok(apartmentlist);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApartmentDto>> GetById(int id)
        {
            var apartment = await apartmentService.GetByIdAsync(id);
            return Ok(apartment);
        }


    }
}
