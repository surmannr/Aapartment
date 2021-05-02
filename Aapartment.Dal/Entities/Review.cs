using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aapartment.Dal.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int Stars { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public int? ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
