using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Aapartment.Web.Refit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Aapartment.Web.Pages.SitePages
{
    public class ApartmentsModel : PageModel
    {
        private readonly IApartmentsApi _apartmentsApi;

        private readonly string SessionKeyFilters = "_Filters";

        public PagedResult<ApartmentDto> Apartments { get; set; }

        [BindProperty]
        public int ShownPage { get; set; } = 8;

        [BindProperty]
        public int TotalRecords { get; set; }

        [BindProperty]
        public int PageNo { get; set; }

        [BindProperty]
        public int PageSize { get; set; }

        public HashSet<string> Filters { get; set; } = new HashSet<string>();
        [BindProperty]
        public string FilterText { get; set; }
        
        public ApartmentsModel(IApartmentsApi apartmentsApi)
        {
            _apartmentsApi = apartmentsApi;
        }

        public async Task OnGet(int pageNumber = 1, int pageSize = 20)
        {
            Filters = HttpContext.Session.Get<HashSet<string>>(SessionKeyFilters) ?? new HashSet<string>();

            PageNo = pageNumber;
            PageSize = pageSize;

            Apartments = await _apartmentsApi.GetAll(PageSize, PageNo, new List<string>(Filters));
            TotalRecords = Apartments.AllResultsCount;
           
        }

        public async Task OnPostFilter()
        {
            PageNo = 1;
            if (PageSize <= 0) PageSize = 20;

            Filters = HttpContext.Session.Get<HashSet<string>>(SessionKeyFilters) ?? new HashSet<string>();
            string value = Request.Form["FilterText"];
            Filters.Add(value);

            HttpContext.Session.Set(SessionKeyFilters, Filters);

            Apartments = await _apartmentsApi.GetAll(PageSize, PageNo, new List<string>(Filters));
            TotalRecords = Apartments.AllResultsCount;
        }

        public async Task<IActionResult> OnPostRemoveFilter(string value)
        {
            PageNo = 1;
            if (PageSize <= 0) PageSize = 20;

            Filters = HttpContext.Session.Get<HashSet<string>>(SessionKeyFilters) ?? new HashSet<string>();
            Filters.Remove(value);

            HttpContext.Session.Set(SessionKeyFilters, Filters);

            Apartments = await _apartmentsApi.GetAll(PageSize, PageNo, new List<string>(Filters));
            TotalRecords = Apartments.AllResultsCount;

            return Page();
        }
    }
}
