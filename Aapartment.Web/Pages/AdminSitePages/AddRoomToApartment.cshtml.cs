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
    public class AddRoomToApartmentModel : PageModel
    {
        private readonly IRoomsApi roomsApi;
        private readonly IApartmentsApi apartmentsApi;

        private readonly string SessionKeyRoom = "_Room";
        private readonly string SessionKeyApartment = "_Apartment";
        public AddRoomToApartmentModel(IApartmentsApi _apartmentsApi, IRoomsApi _roomsApi)
        {
            roomsApi = _roomsApi;
            apartmentsApi = _apartmentsApi;
        }

        public ApartmentDto Apartment { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<RoomDto> Rooms { get; set; }

        public int? Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public RoomDto SelectedRoom { get; set; } = null;

        public async Task OnGet(int? id)
        {
            Rooms = new List<RoomDto>();
            Apartment = new ApartmentDto();
            SelectedRoom = null;
            Id = id;
            if (id != null)
            {
                Apartment = await apartmentsApi.GetById((int)Id);
                Rooms = (List<RoomDto>)await roomsApi.GetAllWithoutPagingByApartmentId((int)Id);
            }
            HttpContext.Session.Set(SessionKeyApartment, Apartment);
            HttpContext.Session.Set(SessionKeyRoom, Rooms);
        }

        public async Task<IActionResult> OnPostRemoveRoom(int roomid)
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Rooms = HttpContext.Session.Get<List<RoomDto>>(SessionKeyRoom);
            Id = Apartment.Id;

            var room = Rooms.Where(c => c.Id == roomid).FirstOrDefault();
            if (room != null)
            {
                await roomsApi.Delete(roomid);
            }

            HttpContext.Session.Set(SessionKeyRoom, Rooms);
            HttpContext.Session.Set(SessionKeyApartment, Apartment);

            return RedirectToPage("AddRoomToApartment");
        }

        public void OnPostSelectRoom(int roomid)
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Rooms = HttpContext.Session.Get<List<RoomDto>>(SessionKeyRoom);
            Id = Apartment.Id;

            var room = Rooms.Where(c => c.Id == roomid).FirstOrDefault();
            if (room != null)
            {
                SelectedRoom = room;
            }

            HttpContext.Session.Set(SessionKeyRoom, Rooms);
            HttpContext.Session.Set(SessionKeyApartment, Apartment);
        }
        public void OnPostClearSelection()
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Rooms = HttpContext.Session.Get<List<RoomDto>>(SessionKeyRoom);
            Id = Apartment.Id;

            SelectedRoom = null;

            HttpContext.Session.Set(SessionKeyRoom, Rooms);
            HttpContext.Session.Set(SessionKeyApartment, Apartment);
        }

        public async Task<IActionResult> OnPostModify(int roomid)
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Rooms = HttpContext.Session.Get<List<RoomDto>>(SessionKeyRoom);
            Id = Apartment.Id;

            bool available = string.IsNullOrEmpty(Request.Form["IsAvailable"].ToString()) ? false : true;
            int roomnumber = int.Parse(Request.Form["RoomNumber"]);
            int maxnumberofpeople = int.Parse(Request.Form["MaxNumberOfPeople"]);
            int priceperadult = int.Parse(Request.Form["PricePerAdult"]);
            int priceperchild = int.Parse(Request.Form["PricePerChild"]);

            RoomDto room = new RoomDto()
            {
                ApartmentId = Apartment.Id,
                IsAvailabe =  available,
                RoomNumber = roomnumber,
                MaxNumberOfPeople = maxnumberofpeople,
                PricePerAdult = priceperadult,
                PricePerChild = priceperchild,
                Id = roomid
            };
            SelectedRoom = null;

            var result = await roomsApi.Modify(roomid, room);

            HttpContext.Session.Set(SessionKeyRoom, Rooms);
            HttpContext.Session.Set(SessionKeyApartment, Apartment);

            return RedirectToPage("AddRoomToApartment");
        }
        public async Task<IActionResult> OnPostCreate()
        {
            Apartment = HttpContext.Session.Get<ApartmentDto>(SessionKeyApartment);
            Rooms = HttpContext.Session.Get<List<RoomDto>>(SessionKeyRoom);
            Id = Apartment.Id;

            bool available = string.IsNullOrEmpty(Request.Form["IsAvailable"].ToString()) ? false : true;
            int roomnumber = int.Parse(Request.Form["RoomNumber"]);
            int maxnumberofpeople = int.Parse(Request.Form["MaxNumberOfPeople"]);
            int priceperadult = int.Parse(Request.Form["PricePerAdult"]);
            int priceperchild = int.Parse(Request.Form["PricePerChild"]);

            RoomDto room = new RoomDto()
            {
                ApartmentId = Apartment.Id,
                IsAvailabe = available,
                RoomNumber = roomnumber,
                MaxNumberOfPeople = maxnumberofpeople,
                PricePerAdult = priceperadult,
                PricePerChild = priceperchild,
            };
            SelectedRoom = null;

            var result = await roomsApi.Create(room);

            HttpContext.Session.Set(SessionKeyRoom, Rooms);
            HttpContext.Session.Set(SessionKeyApartment, Apartment);

            return RedirectToPage("AddRoomToApartment");
        }
    }
}
