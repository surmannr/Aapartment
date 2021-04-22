using Aapartment.Business.Constants;
using Aapartment.Business.SeedInterfaces;
using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aapartment.Business.SeedServices
{
    public class AdminSeedService : IAdminSeedService
    {
        private readonly UserManager<User> userManager;

        public AdminSeedService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task SeedAdminAsync()
        {
            if (!(await userManager.GetUsersInRoleAsync(Roles.Admin.ToUpper())).Any())
            {
                var user = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@aapartment.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    UserName = "admin"
                };

                var createResult = await userManager.CreateAsync(user, "asd123ASD?");
                var addToRoleResult = await userManager.AddToRoleAsync(user, Roles.Admin.ToUpper());

                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                {
                    throw new ApplicationException("Administrator clould not be created:" +
                        String.Join(", ", createResult.Errors.Concat(addToRoleResult.Errors).Select(e => e.Description)));
                }
            }
        }
    }
}
