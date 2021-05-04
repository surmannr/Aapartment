using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aapartment.Business.Config;
using Aapartment.Business.Constants;
using Aapartment.Business.Dto;
using Aapartment.Dal.Entities;
using Aapartment.Web.Refit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            
            ServiceList = new List<SelectListItem> {
                            new SelectListItem { Value = Services.Airport_ICON, Text = Services.Airport_NAME },
                            new SelectListItem { Value = Services.Family_ICON, Text = Services.Family_NAME },
                            new SelectListItem { Value = Services.FreeWifi_ICON, Text = Services.FreeWifi_NAME },
                            new SelectListItem { Value = Services.NonSmoking_ICON, Text = Services.NonSmoking_NAME },
                            new SelectListItem { Value = Services.Pets_ICON, Text = Services.Pets_NAME },
                            new SelectListItem { Value = Services.Terrace_ICON, Text = Services.Terrace_NAME }
                    };
        }

        [BindProperty(SupportsGet = true)]
        public ApartmentDto Apartment { get; set; }

        public int? Id { get; set; }


        [BindProperty]
        public string Service { get; set; } = "";
        public List<SelectListItem> ServiceList { get; set; }

        public async Task OnGet(int? id)
        {

            Apartment = new ApartmentDto();
            Id = id;
            if(id != null)
            {
                Apartment =  await apartmentsApi.GetById((int)Id);
            }
            FinalPage();

        }
        [BindProperty]
        public IFormFile Upload { get; set; }

        [Obsolete]
        public async Task<IActionResult> OnPostCreateOrModify()
        {
            InitPage();

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

            ApartmentDto result = new ApartmentDto();
            if(Apartment.Id == 0)
            {
                result = await apartmentsApi.Create(Apartment);
            }
            else
            {
                result = await apartmentsApi.Modify(Apartment.Id, Apartment);
            }
            
            return RedirectToPage("./ApartmentManagement");
        }

        public void OnPostRemoveService(int serviceid)
        {
            InitPage();

            var service = Apartment.Services.Where(c => c.Id == serviceid).FirstOrDefault();
            if(service != null)
            {
                Apartment.Services.Remove(service);
            }

            FinalPage();
        }

        public void OnPostAddService()
        {
            InitPage();

            var listitem = ServiceList.Where(c => c.Value == Service).FirstOrDefault();
            Service service = new Service()
            {
                Icon = listitem.Value,
                Name = listitem.Text
            };
            if (service != null)
            {
                var checkuniq = Apartment.Services.Where(c => c.Name == service.Name).FirstOrDefault();
                if(checkuniq == null)
                {
                    Apartment.Services.Add(service);
                }
                
            }

            FinalPage();
        }

        private void InitPage()
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Id = Apartment.Id;

            Apartment.Name = Request.Form["Name"];
            Apartment.Description = Request.Form["Description"];
            string zip = Request.Form["Zip"].ToString();
            if (string.IsNullOrEmpty(zip))
                Apartment.Address.ZipCode = 0;
            else
                Apartment.Address.ZipCode = int.Parse(zip);
            Apartment.Address.Street = Request.Form["Street"];
            Apartment.Address.Country = Request.Form["Country"];
            Apartment.Address.City = Request.Form["City"];
        }

        private void FinalPage()
        {
            HttpContext.Session.Set(SessionKeyApartment, Apartment);
        }
    }
}
