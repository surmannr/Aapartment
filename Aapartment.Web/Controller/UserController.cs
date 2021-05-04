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

    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILoggerManager logger;

        public UserController(IUserService _userService, ILoggerManager logger)
        {
            userService = _userService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<UserDto>>> GetAll([FromQuery] int size, [FromQuery] int page)
        {
            var users = await userService.GetAllPagedAsync(size, page);
            logger.LogInfo($"Get all users successfully.");
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await userService.GetByIdAsync(id);
            logger.LogInfo($"Get user by id:{id} successfully.");
            return Ok(user);
        }

        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<UserDto>> Create([FromBody] UserDto userDto)
        {
            var user = await userService.CreateUserAsync(userDto);
            logger.LogInfo($"Create user successfully.");
            return Ok(user);
        }

        [HttpPost]
        [Route("admin")]
        public async Task<ActionResult<UserDto>> CreateAdmin([FromBody] UserDto userDto)
        {
            var user = await userService.CreateAdminAsync(userDto);
            logger.LogInfo($"Create admin successfully.");
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await userService.DeleteAsync(id);
            logger.LogInfo($"Delete user by id:{id} successfully.");
            return Ok();
        }

        [HttpPatch]
        [Route("{id}/email")]
        public async Task<ActionResult<UserDto>> ModifyEmail(int id, [FromQuery] string email)
        {
            var user = await userService.ModifyEmailAsync(id, email);
            logger.LogInfo($"Modify user email by id:{id} successfully.");
            return Ok(user);
        }

        [HttpPatch]
        [Route("{id}/username")]
        public async Task<ActionResult<UserDto>> ModifyUserName(int id, [FromQuery] string username)
        {
            var user = await userService.ModifyUserNameAsync(id, username);
            logger.LogInfo($"Modify user username by id:{id} successfully.");
            return Ok(user);
        }

        [HttpPatch]
        [Route("{id}/name")]
        public async Task<ActionResult<UserDto>> ModifyName(int id, [FromQuery] string lastname, [FromQuery] string firstname)
        {
            var user = await userService.ModifyNameAsync(id, firstname,lastname);
            logger.LogInfo($"Modify user name by id:{id} successfully.");
            return Ok(user);
        }

        [HttpPatch]
        [Route("{id}/password")]
        public async Task<ActionResult<UserDto>> ModifyPassword(int id, [FromBody] PasswordChangeDto password)
        {
            var user = await userService.ModifyPasswordAsync(id, password.CurrentPassword, password.NewPassword);
            logger.LogInfo($"Modify user password by id:{id} successfully.");
            return Ok(user);
        }
    }
}
