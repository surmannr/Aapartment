using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SumPrice { get; set; }
        public bool IsPaid { get; set; } = false;
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
