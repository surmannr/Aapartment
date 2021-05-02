using Aapartment.Business.Dto;
using Aapartment.Business.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll([FromQuery] int size, [FromQuery] int page)
        {
            var users = await userService.GetAllPagedAsync(size, page);
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<UserDto>> Create([FromBody] UserDto userDto)
        {
            var user = await userService.CreateUserAsync(userDto);
            return Ok(user);
        }

        [HttpPost]
        [Route("admin")]
        public async Task<ActionResult<UserDto>> CreateAdmin([FromBody] UserDto userDto)
        {
            var user = await userService.CreateAdminAsync(userDto);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await userService.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("{id}/email")]
        public async Task<ActionResult<UserDto>> ModifyEmail(int id, [FromQuery] string email)
        {
            var user = await userService.ModifyEmailAsync(id, email);
            return Ok(user);
        }

        [HttpPatch]
        [Route("{id}/username")]
        public async Task<ActionResult<UserDto>> ModifyUserName(int id, [FromQuery] string username)
        {
            var user = await userService.ModifyUserNameAsync(id, username);
            return Ok(user);
        }

        [HttpPatch]
        [Route("{id}/name")]
        public async Task<ActionResult<UserDto>> ModifyName(int id, [FromQuery] string lastname, [FromQuery] string firstname)
        {
            var user = await userService.ModifyNameAsync(id, firstname,lastname);
            return Ok(user);
        }

        [HttpPatch]
        [Route("{id}/password")]
        public async Task<ActionResult<UserDto>> ModifyPassword(int id, [FromBody] PasswordChangeDto password)
        {
            var user = await userService.ModifyPasswordAsync(id, password.CurrentPassword, password.NewPassword);
            return Ok(user);
        }
    }
}
