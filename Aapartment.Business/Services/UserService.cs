using Aapartment.Business.Dto;
using Aapartment.Business.Exceptions;
using Aapartment.Business.Config;
using Aapartment.Dal;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Aapartment.Business.Constants;
using Aapartment.Business.ServiceInterfaces;

namespace Aapartment.Business.Services
{
    public class UserService : IUserService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserService(AapartmentDbContext _db, IMapper _mapper, UserManager<User> um)
        {
            db = _db;
            mapper = _mapper;
            userManager = um;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var users = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (users == null) throw new DbNullException();
            return mapper.Map<UserDto>(users);
        }

        public async Task<IEnumerable<UserDto>> GetAllPagedAsync(int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0) throw new QueryParamsNullException();
            var users = await db.Users.Paging(pagesize, pagenumber, a => a.UserName).ToListAsync();
            return mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            if (CheckIfValid(userDto))
            {

                var user = mapper.Map<User>(userDto);
                var result = await userManager.CreateAsync(user,userDto.Password);
                if (!result.Succeeded) throw new DbNullException();
                await userManager.AddToRoleAsync(user, Roles.Guest);
                await db.SaveChangesAsync();
                return mapper.Map<UserDto>(user);

            }
            else throw new QueryParamsNullException();
        }
        public async Task<UserDto> CreateAdminAsync(UserDto userDto)
        {
            if (CheckIfValid(userDto))
            {

                var user = mapper.Map<User>(userDto);
                var result = await userManager.CreateAsync(user, userDto.Password);
                if (!result.Succeeded) throw new DbNullException();
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await db.SaveChangesAsync();
                return mapper.Map<UserDto>(user);

            }
            else throw new QueryParamsNullException();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null) throw new DbNullException();
            db.Users.Remove(user);
            await db.SaveChangesAsync();
        }

        public async Task<UserDto> ModifyEmailAsync(int id, string email)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null) throw new DbNullException();

            user.Email = string.IsNullOrEmpty(email) ? user.Email : email ;

            await db.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ModifyUserNameAsync(int id, string username)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null) throw new DbNullException();

            user.UserName = string.IsNullOrEmpty(username) ? user.UserName : username;

            await db.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ModifyNameAsync(int id, string fname, string lname)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null) throw new DbNullException();

            user.FirstName = string.IsNullOrEmpty(fname) ? user.FirstName : fname;
            user.LastName = string.IsNullOrEmpty(lname) ? user.LastName : lname;

            await db.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ModifyPasswordAsync(int id, string password)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null) throw new DbNullException();

            if (string.IsNullOrEmpty(password)) throw new QueryParamsNullException();

            await userManager.RemovePasswordAsync(user);
            await userManager.AddPasswordAsync(user, password);

            await db.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public bool CheckIfValid(UserDto user)
        {
            if (string.IsNullOrEmpty(user.Email)) return false;
            if (string.IsNullOrEmpty(user.FirstName)) return false;
            if (string.IsNullOrEmpty(user.LastName)) return false;
            if (string.IsNullOrEmpty(user.UserName)) return false;
            if (string.IsNullOrEmpty(user.Password)) return false;
            return true;
        }
    }
}
