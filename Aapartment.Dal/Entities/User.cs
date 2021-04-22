using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public User()
        {
            Reviews = new HashSet<Review>();
            Bookings = new HashSet<Booking>();
        }
    }
}
