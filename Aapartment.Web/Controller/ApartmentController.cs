using Aapartment.Business.Config;
using Aapartment.Business.Constants;
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
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService apartmentService;
        private readonly ILoggerManager logger;

        public ApartmentsController(IApartmentService _apartmentService, ILoggerManager logger)
        {
            apartmentService = _apartmentService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<ApartmentDto>>> GetAll([FromQuery]int pageSize, [FromQuery] int pageNumber, [FromBody] List<string> filters)
        {
            var apartmentlist = await apartmentService.GetAllPagedAsync(pageSize, pageNumber, filters);
            logger.LogInfo("Get all apartments successfully.");
            return Ok(apartmentlist);
        }

        [HttpGet]
        [Route("pagecount")]
        public async Task<ActionResult<int>> GetPageCount([FromQuery] int size)
        {
            var count = await apartmentService.GetPageCounts(size);
            logger.LogInfo("Get apartments count successfully.");
            return Ok(count);
        }

        [HttpGet]
        [Route("recommendation")]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetRecommendation([FromQuery] int size, [FromQuery] int page)
        {
            var apartmentlist = await apartmentService.GetRecommendation(size, page);
            logger.LogInfo("Get all recommended apartments successfully.");
            return Ok(apartmentlist);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApartmentDto>> GetById(int id)
        {
            var apartment = await apartmentService.GetByIdAsync(id);
            logger.LogInfo($"Get apartment by id:{id} successfully.");
            return Ok(apartment);
        }

        [HttpPost]
        public async Task<ActionResult<ApartmentDto>> Create([FromBody] ApartmentDto apartmentDto)
        {
            var apartment = await apartmentService.CreateAsync(apartmentDto);
            logger.LogInfo("Create a new apartment successfully.");
            return Ok(apartment);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await apartmentService.DeleteAsync(id);
            logger.LogInfo($"Delete apartment by id:{id} successfully.");
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ApartmentDto>> Modify(int id, [FromBody] ApartmentDto apartmentDto)
        {
            var apartment = await apartmentService.ModifyAsync(id, apartmentDto);
            logger.LogInfo($"Modify apartment by id:{id} successfully.");
            return Ok(apartment);
        }
    }
}
