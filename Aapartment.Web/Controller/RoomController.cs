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
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly ILoggerManager logger;

        public RoomController(IRoomService _roomService, ILoggerManager logger)
        {
            roomService = _roomService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAll([FromQuery] int size, [FromQuery] int page)
        {
            var rooms = await roomService.GetAllPagedAsync(size, page);
            logger.LogInfo($"Get all rooms successfully.");
            return Ok(rooms);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllWithoutPagingByApartmentId([FromQuery] int apartmentid)
        {
            var rooms = await roomService.GetAllByApartmentIdAsync(apartmentid);
            logger.LogInfo($"Get all rooms by apartmentid:{apartmentid} successfully.");
            return Ok(rooms);
        }

        [HttpGet]
        [Route("aid/{id}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllByApartmentId(int id,[FromQuery] int size, [FromQuery] int page)
        {
            var rooms = await roomService.GetAllPagedByApartmentIdAsync(id,size, page);
            logger.LogInfo($"Get all rooms by apartmentid:{id} successfully.");
            return Ok(rooms);
        }

        [HttpGet]
        [Route("aid/{id}/count")]
        public async Task<ActionResult<int>> GetAllByApartmentIdCount(int id)
        {
            var roomscount = await roomService.GetAllCountByApartmentId(id);
            logger.LogInfo($"Get all rooms count by apartmentid:{id} successfully.");
            return Ok(roomscount);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Create([FromBody] RoomDto roomDto)
        {
            var room = await roomService.CreateAsync(roomDto);
            logger.LogInfo($"Create a new room successfully.");
            return Ok(room);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await roomService.DeleteAsync(id);
            logger.LogInfo($"Delete room by id:{id} successfully.");
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<RoomDto>> Modify(int id, [FromBody]RoomDto roomDto)
        {
            var room = await roomService.ModifyAsync(id, roomDto);
            logger.LogInfo($"Modify room by id:{id} successfully.");
            return Ok(room);
        }

        [HttpPatch]
        [Route("{id}/available")]
        public async Task<ActionResult<RoomDto>> ModifyAvailable(int id, [FromQuery] bool available )
        {
            var room = await roomService.ModifyAvailableAsync(id, available);
            logger.LogInfo($"Modify room availability by id:{id} successfully.");
            return Ok(room);
        }
    }
}
