using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Refit
{
    public interface IUserApi
    {
        [Get("")]
        Task<PagedResult<UserDto>> GetAll([Query] int size, [Query] int page);

        [Get("/{id}")]
        Task<UserDto> GetById(int id);

        [Post("/user")]
        Task<UserDto> Create([Body] UserDto userDto);

        [Post("/admin")]
        Task<UserDto> CreateAdmin([Body] UserDto userDto);

        [Delete("/{id}")]
        Task Delete(int id);

        [Patch("/{id}/email")]
        Task<UserDto> ModifyEmail(int id, [Query] string email);

        [Patch("/{id}/username")]
        Task<UserDto> ModifyUserName(int id, [Query] string username);

        [Patch("/{id}/name")]
        Task<UserDto> ModifyName(int id, [Query] string lastname, [Query] string firstname);

        [Patch("/{id}/password")]
        Task<UserDto> ModifyPassword(int id, [Body] string password);
    }
}
