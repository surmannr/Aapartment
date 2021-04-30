using Aapartment.Business.Dto;
using Aapartment.Business.ServiceInterfaces;
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

        public RoomController(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAll([FromQuery] int size, [FromQuery] int page)
        {
            var rooms = await roomService.GetAllPagedAsync(size, page);
            return Ok(rooms);
        }

        [HttpGet]
        [Route("aid/{id}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllByApartmentId(int id,[FromQuery] int size, [FromQuery] int page)
        {
            var rooms = await roomService.GetAllPagedByApartmentIdAsync(id,size, page);
            return Ok(rooms);
        }

        [HttpGet]
        [Route("aid/{id}/count")]
        public async Task<ActionResult<int>> GetAllByApartmentIdCount(int id)
        {
            var roomscount = await roomService.GetAllCountByApartmentId(id);
            return Ok(roomscount);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Create([FromBody] RoomDto roomDto)
        {
            var room = await roomService.CreateAsync(roomDto);
            return Ok(room);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await roomService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<RoomDto>> Modify(int id, [FromBody]RoomDto roomDto)
        {
            var room = await roomService.ModifyAsync(id, roomDto);
            return Ok(room);
        }

        [HttpPatch]
        [Route("{id}/available")]
        public async Task<ActionResult<RoomDto>> ModifyAvailable(int id, [FromQuery] bool available )
        {
            var room = await roomService.ModifyAvailableAsync(id, available);
            return Ok(room);
        }
    }
}
