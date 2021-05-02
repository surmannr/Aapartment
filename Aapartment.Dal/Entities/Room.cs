using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aapartment.Dal.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }
        [Range(0,int.MaxValue)]
        public int PricePerAdult { get; set; }
        [Range(0, int.MaxValue)]
        public int PricePerChild { get; set; }
        [Range(0, int.MaxValue)]
        public int MaxNumberOfPeople { get; set; }
        public bool IsAvailabe { get; set; }

        public int? ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Room()
        {
            Bookings = new HashSet<Booking>();
        }
    }
}
