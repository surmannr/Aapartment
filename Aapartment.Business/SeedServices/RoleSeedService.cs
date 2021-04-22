using Aapartment.Business.Constants;
using Aapartment.Business.SeedInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aapartment.Business.SeedServices
{
    public class RoleSeedService : IRoleSeedService
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public RoleSeedService(RoleManager<IdentityRole<int>> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task SeedRoleAsync()
        {
            PropertyInfo[] propertyInfos = typeof(Roles).GetProperties();
            foreach (var role in propertyInfos)
            {
                if (!await roleManager.RoleExistsAsync(role.Name.ToUpper()))
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = role.Name.ToUpper()});
            }
            
        }
    }
}
