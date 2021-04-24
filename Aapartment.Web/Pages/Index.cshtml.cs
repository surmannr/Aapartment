using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Aapartment.Business.Dto;

namespace Aapartment.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _clientFactory;

        [BindProperty(SupportsGet = true)]
        public List<ApartmentDto> Apartments { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var httpClient = _clientFactory.CreateClient("base");
            Apartments = await httpClient.GetFromJsonAsync<List<ApartmentDto>>($"api/apartments/recommendation?size=4&page=1");
        }
    }
}
