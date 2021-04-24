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

        [HttpPost]
        public async Task<ActionResult<ApartmentDto>> Create([FromBody] ApartmentDto apartmentDto)
        {
            var apartment = await apartmentService.CreateAsync(apartmentDto);
            return Ok(apartment);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await apartmentService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ApartmentDto>> Modify(int id, [FromBody] ApartmentDto apartmentDto)
        {
            var apartment = await apartmentService.ModifyAsync(id, apartmentDto);
            return Ok(apartment);
        }
    }
}
