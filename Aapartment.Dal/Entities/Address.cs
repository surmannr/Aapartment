using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.Entities
{
    [Owned]
    public class Address
    {
        public int? ApartmentId { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
