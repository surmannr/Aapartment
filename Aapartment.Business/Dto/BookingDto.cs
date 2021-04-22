using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SumPrice { get; set; }
        public bool IsPaid { get; set; } = false;
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
