using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Aapartment.Web.Refit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aapartment.Web.Pages.AdminSitePages
{
    public class UserManagementModel : PageModel
    {
        private readonly IUserApi userApi;

        public UserManagementModel(IUserApi _userApi)
        {
            userApi = _userApi;
        }
        [BindProperty]
        public PagedResult<UserDto> Users { get; set; } = new PagedResult<UserDto>();
        public async Task OnGet(int pageNumber = 1, int pageSize = 10)
        {
            Users.PageNumber = pageNumber;
            Users.PageSize = pageSize;
            Users = await userApi.GetAll(pageSize, pageNumber);
        }
    }
}
