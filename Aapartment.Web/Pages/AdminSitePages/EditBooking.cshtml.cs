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
    public class EditBookingModel : PageModel
    {
        private readonly IBookingApi bookingsApi;
        private readonly IUserApi userApi;
        private readonly string SessionKeyBooking = "_Booking";
        private readonly string SessionKeyUser = "_User";

        public EditBookingModel(IBookingApi _bookingsApi, IUserApi _userApi)
        {
            bookingsApi = _bookingsApi;
            userApi = _userApi;
        }

        [BindProperty(SupportsGet = true)]
        public BookingDto Booking { get; set; }
        [BindProperty(SupportsGet = true)]
        public UserDto UserLogged { get; set; }

        public int Id { get; set; }

        public async Task OnGet(int id)
        {
            Booking = new BookingDto();
            Id = id;
            Booking = await bookingsApi.GetById(Id);
            if(Booking != null)
            {
                UserLogged = await userApi.GetById(Booking.UserId);
            }
            FinalPage();
        }

        public async Task<IActionResult> OnPost()
        {
            InitPage();

            var paid = Request.Form["IsPaid"];
            Booking.IsPaid = string.IsNullOrEmpty(paid) ? false : true;
            await bookingsApi.ModifyStatus(Booking.IsPaid, Booking.Id);

            FinalPage();

            return RedirectToPage("./BookingManagement");
        }

        private void InitPage()
        {
            Booking = HttpContext.Session.Get<BookingDto>(SessionKeyBooking);
            UserLogged = HttpContext.Session.Get<UserDto>(SessionKeyUser);
            Id = Booking.Id;

            string ispaid = Request.Form["IsPaid"];
            if (ispaid == "Yes")
                Booking.IsPaid = true;
            else
                Booking.IsPaid = false;
        }

        private void FinalPage()
        {
            HttpContext.Session.Set(SessionKeyBooking, Booking);
            HttpContext.Session.Set(SessionKeyUser, UserLogged);
        }
    }
}
