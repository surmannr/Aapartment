using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.Entities
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public string ImageName { get; set; }
        public ICollection<Service> Services { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public Apartment()
        {
            Services = new HashSet<Service>();
            Rooms = new HashSet<Room>();
            Reviews = new HashSet<Review>();
        }
    }
}
