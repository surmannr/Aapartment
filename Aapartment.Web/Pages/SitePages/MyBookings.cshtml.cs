using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Aapartment.Business.Config;
using Aapartment.Business.Dto;
using Aapartment.Web.Refit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aapartment.Web.Pages.SitePages
{
    public class MyBookingsModel : PageModel
    {
        private readonly IBookingApi bookingApi;

        public MyBookingsModel(IBookingApi bookingApi)
        {
            this.bookingApi = bookingApi;
        }

        [BindProperty]
        public PagedResult<BookingDto> Bookings { get; set; } = new PagedResult<BookingDto>();


        public async Task OnGet(int pagesize = 8, int pagenumber = 1)
        {
            Bookings.PageNumber = pagenumber;
            Bookings.PageSize = pagesize;
            string useridvalue = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(useridvalue != null)
            {
                var userId = int.Parse(useridvalue);
                Bookings = await bookingApi.GetAllByUserId(Bookings.PageSize, Bookings.PageNumber, userId);
            }
        }
    }
}
