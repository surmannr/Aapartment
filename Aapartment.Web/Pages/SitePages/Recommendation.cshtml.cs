using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Aapartment.Web.Refit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aapartment.Web.Pages.SitePages
{
    public class RecommendationModel : PageModel
    {
        private readonly IApartmentsApi _apartmentsApi;
        private readonly string SessionKeyOption = "_Option";
        [BindProperty]
        public int Option { get; set; }

        public IEnumerable<ApartmentDto> Apartments { get; set; }

        public RecommendationModel(IApartmentsApi apartmentsApi)
        {
            _apartmentsApi = apartmentsApi;
        }

        public void OnGet()
        {
            Option = HttpContext.Session.Get<int>(SessionKeyOption);
        }

        public async Task OnPostSearch()
        {
            int size = Option;
            int page = 1;

            Apartments = await _apartmentsApi.GetRecommendation(size, page);

            HttpContext.Session.Set(SessionKeyOption, Option);
        }
    }
}
