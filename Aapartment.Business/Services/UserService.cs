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
using Aapartment.Business.Logger;

namespace Aapartment.Business.Services
{
    public class UserService : IUserService
    {
        private readonly AapartmentDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ILoggerManager logger;

        public UserService(AapartmentDbContext _db, IMapper _mapper, UserManager<User> um, ILoggerManager logger)
        {
            db = _db;
            mapper = _mapper;
            userManager = um;
            this.logger = logger;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var users = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (users == null)
            {
                logger.LogError($"Error: user with id:{id} does not exist.");
                throw new DbNullException();
            }
            return mapper.Map<UserDto>(users);
        }

        public async Task<User> GetByIdModelAsync(int id)
        {
            var users = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (users == null)
            {
                logger.LogError($"Error: user with id:{id} does not exist.");
                throw new DbNullException();
            }
            return users;
        }

        public async Task<PagedResult<UserDto>> GetAllPagedAsync(int pagesize, int pagenumber)
        {
            if (pagenumber <= 0 || pagesize <= 0)
            {
                logger.LogError($"Error: paging failed - pagenumber: {pagenumber} && pagesize: {pagesize}");
                throw new QueryParamsNullException();
            }
            var users = await db.Users.OrderBy(a => a.UserName).Paging(pagesize, pagenumber).ToListAsync();
            int userscount = await db.Users.CountAsync();
            PagedResult<UserDto> result = new PagedResult<UserDto>();
            result.AllResultsCount = userscount;
            result.PageNumber = pagenumber;
            result.PageSize = pagesize;
            result.Results = mapper.Map<List<UserDto>>(users);
            return result;
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            if (CheckIfValid(userDto))
            {

                var user = mapper.Map<User>(userDto);
                var result = await userManager.CreateAsync(user, userDto.Password);

                if (!result.Succeeded) {
                    logger.LogError($"Validation failed for creating user.");
                    throw new DbNullException();
                }
               
                var currentUser = await userManager.FindByNameAsync(user.UserName);
                await userManager.AddToRoleAsync(currentUser, Roles.Guest);
                await db.SaveChangesAsync();
                return mapper.Map<UserDto>(currentUser);

            }
            else {
                logger.LogError($"Validation failed for creating user.");
                throw new QueryParamsNullException();
            } 
        }
        public async Task<UserDto> CreateAdminAsync(UserDto userDto)
        {
            if (CheckIfValid(userDto))
            {

                var user = mapper.Map<User>(userDto);
                user.EmailConfirmed = true;
                var result = await userManager.CreateAsync(user, userDto.Password);
                if (!result.Succeeded)
                {
                    logger.LogError($"Validation failed for creating admin.");
                    throw new DbNullException();
                }
                var currentUser = await userManager.FindByNameAsync(user.UserName);
                await userManager.AddToRoleAsync(currentUser, Roles.Admin);
                await db.SaveChangesAsync();
                return mapper.Map<UserDto>(currentUser);

            }
            else
            {
                logger.LogError($"Validation failed for creating admin.");
                throw new QueryParamsNullException();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = await db.Users.Where(a => a.Id == id).Include(e => e.Bookings).Include(e => e.Reviews).FirstOrDefaultAsync();
            if (user == null)
            {
                logger.LogError($"Error: user with id:{id} does not exist.");
                throw new DbNullException();
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                foreach(var booking in user.Bookings)
                {
                    db.Bookings.Remove(booking);
                }
                foreach(var review in user.Reviews)
                {
                    db.Reviews.Remove(review);
                }

                db.Users.Remove(user);

                await db.SaveChangesAsync();

                await transaction.CommitAsync();
            }
        }

        public async Task<UserDto> ModifyEmailAsync(int id, string email)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                logger.LogError($"Error: user with id:{id} does not exist.");
                throw new DbNullException();
            }

            user.Email = string.IsNullOrEmpty(email) ? user.Email : email ;

            await db.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ModifyUserNameAsync(int id, string username)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                logger.LogError($"Error: user with id:{id} does not exist.");
                throw new DbNullException();
            }

            user.UserName = string.IsNullOrEmpty(username) ? user.UserName : username;

            await db.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ModifyNameAsync(int id, string fname, string lname)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                logger.LogError($"Error: user with id:{id} does not exist.");
                throw new DbNullException();
            }

            user.FirstName = string.IsNullOrEmpty(fname) ? user.FirstName : fname;
            user.LastName = string.IsNullOrEmpty(lname) ? user.LastName : lname;

            await db.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ModifyPasswordAsync(int id, string currentPassword,string newpassword)
        {
            var user = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                logger.LogError($"Error: user with id:{id} does not exist.");
                throw new DbNullException();
            }

            if (string.IsNullOrEmpty(currentPassword)) {
                logger.LogError($"Empty password parameter.");
                throw new QueryParamsNullException();
            } 
            if (string.IsNullOrEmpty(newpassword))
            {
                logger.LogError($"Empty confirm password parameter.");
                throw new QueryParamsNullException();
            }

            await userManager.ChangePasswordAsync(user, currentPassword, newpassword);

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
