using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aapartment.Web
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User,IdentityRole<int>>
    {

        public MyUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("AllName", user.FirstName + " " + user.LastName));
            return identity;
        }
    }
}
