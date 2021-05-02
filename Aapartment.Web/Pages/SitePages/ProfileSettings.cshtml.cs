using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Aapartment.Business.Dto;
using Aapartment.Web.Refit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aapartment.Web.Pages.SitePages
{
    public class ProfileSettingsModel : PageModel
    {
        private readonly IUserApi userApi;

        public ProfileSettingsModel(IUserApi _userApi)
        {
            userApi = _userApi;
        }

        public UserDto CurrentUser { get; set; }

        public async Task OnGet()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            CurrentUser = await userApi.GetById(userId);
        }
    }
}
