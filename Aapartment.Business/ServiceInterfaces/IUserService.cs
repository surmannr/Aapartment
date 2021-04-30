using Aapartment.Business.Dto;
using Aapartment.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aapartment.Business.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task<User> GetByIdModelAsync(int id);
        Task<IEnumerable<UserDto>> GetAllPagedAsync(int pagesize, int pagenumber);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> CreateAdminAsync(UserDto userDto);
        Task DeleteAsync(int id);
        Task<UserDto> ModifyEmailAsync(int id, string email);
        Task<UserDto> ModifyUserNameAsync(int id, string username);
        Task<UserDto> ModifyNameAsync(int id, string fname, string lname);
        Task<UserDto> ModifyPasswordAsync(int id, string password);
    }
}
