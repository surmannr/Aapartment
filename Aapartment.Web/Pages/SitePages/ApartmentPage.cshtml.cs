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
    public class ApartmentPageModel : PageModel
    {
        private readonly IApartmentsApi _apartmentsApi;
        private readonly IRoomsApi _roomsApi;
        private readonly IReviewsApi _reviewsApi;

        public ApartmentDto Apartment { get; set; } = new ApartmentDto();

        public PagedResult<RoomDto> RoomsForApartment { get; set; } = new PagedResult<RoomDto>();
        [BindProperty]
        public int RoomPageNumber { get; set; }
        [BindProperty]
        public int RoomPageSize { get; set; }

        public PagedResult<ReviewDto> ReviewsForApartment { get; set; } = new PagedResult<ReviewDto>();
        [BindProperty]
        public int ReviewPageNumber { get; set; } = 1;
        [BindProperty]
        public int ReviewPageSize { get; set; } = 10;

        public string Name { get; set; } = "";
        public ApartmentPageModel(IApartmentsApi apartmentsApi, IRoomsApi roomsApi, IReviewsApi reviewsApi)
        {
            _apartmentsApi = apartmentsApi;
            _roomsApi = roomsApi;
            _reviewsApi = reviewsApi;
        }
        public async Task OnGet(int id, int roomPageNumber = 1, int roomPageSize = 4)
        {
            Apartment = await _apartmentsApi.GetById(id);

            RoomPageNumber = roomPageNumber;
            RoomPageSize = roomPageSize;

            Name = User.FindFirstValue("AllName");

            RoomsForApartment.PageSize = RoomPageSize;
            RoomsForApartment.PageNumber = RoomPageNumber;
            RoomsForApartment.Results = await _roomsApi.GetAllByApartmentId(id, RoomPageSize, RoomPageNumber);
            RoomsForApartment.AllResultsCount = await _roomsApi.GetAllByApartmentIdCount(id);

            ReviewsForApartment.PageSize = ReviewPageSize;
            ReviewsForApartment.PageNumber = ReviewPageNumber;
            ReviewsForApartment.Results = await _reviewsApi.GetAllByApartmentId(id, ReviewPageSize, ReviewPageNumber);
            ReviewsForApartment.AllResultsCount = ReviewsForApartment.Results.Count();
        }
    }
}
