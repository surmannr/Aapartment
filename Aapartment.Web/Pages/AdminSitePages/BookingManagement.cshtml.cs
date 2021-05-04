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
    public class BookingManagementModel : PageModel
    {
        private readonly IBookingApi bookingApi;

        public BookingManagementModel(IBookingApi _bookingApi)
        {
            bookingApi = _bookingApi;
        }

        [BindProperty]
        public PagedResult<BookingDto> Bookings { get; set; } = new PagedResult<BookingDto>();

        public async Task OnGet(int pageNumber = 1, int pageSize = 10)
        {
            Bookings.PageNumber = pageNumber;
            Bookings.PageSize = pageSize;
            Bookings = await bookingApi.GetAll(pageSize, pageNumber);
        }
    }
}
