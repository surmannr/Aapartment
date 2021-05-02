using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Aapartment.Web.Refit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aapartment.Web.Pages.AdminSitePages
{
    public class CreateOrEditApartmentModel : PageModel
    {
        private readonly IApartmentsApi apartmentsApi;
        [Obsolete]
        private readonly IHostingEnvironment environment;
        private readonly string SessionKeyApartment = "_Apartment";

        [Obsolete]
        public CreateOrEditApartmentModel(IApartmentsApi _apartmentsApi, IHostingEnvironment environment)
        {
            apartmentsApi = _apartmentsApi;
            this.environment = environment;
        }
        [BindProperty(SupportsGet = true)]
        public ApartmentDto Apartment { get; set; }
        public int? Id { get; set; }

        public async Task OnGet(int? id)
        {
            Apartment = new ApartmentDto();
            Id = id;
            if(id != null)
            {
                Apartment =  await apartmentsApi.GetById((int)Id);
            }
            HttpContext.Session.Set(SessionKeyApartment, Apartment);

        }
        [BindProperty]
        public IFormFile Upload { get; set; }

        [Obsolete]
        public async Task<IActionResult> OnPostCreateOrModify()
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Apartment.Name = Request.Form["Name"];
            Apartment.Description = Request.Form["Description"];
            Apartment.Address.ZipCode = int.Parse(Request.Form["Zip"]);
            Apartment.Address.Street = Request.Form["Street"];
            Apartment.Address.Country = Request.Form["Country"];
            Apartment.Address.City = Request.Form["City"];
            if (string.IsNullOrEmpty(Apartment.ImageName))
            {
                Apartment.ImageName = Guid.NewGuid().ToString() + ".jpg";
            }
            var file = Path.Combine(environment.ContentRootPath, "wwwroot/images", Apartment.ImageName);
            if (file != null && Upload != null)
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }
            if(Apartment.Id == 0)
            {
                await apartmentsApi.Create(Apartment);
            }
            else
            {
                await apartmentsApi.Modify(Apartment.Id, Apartment);
            }
            return RedirectToPage("./ApartmentManagement");
        }

        public void OnPostRemoveService(int serviceid)
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Id = Apartment.Id;
            var service = Apartment.Services.Where(c => c.Id == serviceid).FirstOrDefault();
            if(service != null)
            {
                Apartment.Services.Remove(service);
            }
            HttpContext.Session.Set(SessionKeyApartment, Apartment);
        }

    }
}
