using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Dto
{
    public class RoomDto
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerChild { get; set; }
        public int MaxNumberOfPeople { get; set; }
        public bool IsAvailabe { get; set; }

        public int ApartmentId { get; set; }
    }
}
