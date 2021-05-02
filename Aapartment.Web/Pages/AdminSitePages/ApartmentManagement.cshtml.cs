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
    public class ApartmentManagementModel : PageModel
    {
        private readonly IApartmentsApi apartmentsApi;

        public ApartmentManagementModel(IApartmentsApi _apartmentsApi)
        {
            apartmentsApi = _apartmentsApi;
        }

        [BindProperty]
        public PagedResult<ApartmentDto> Apartments { get; set; } = new PagedResult<ApartmentDto>();

        public async Task OnGet(int pageNumber = 1, int pageSize = 20)
        {
            Apartments.PageNumber = pageNumber;
            Apartments.PageSize = pageSize;
            Apartments = await apartmentsApi.GetAll(pageSize,pageNumber, new List<string>());
        }
    }
}
