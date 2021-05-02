using Aapartment.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Dto
{
    public class ApartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public string ImageName { get; set; }

        public int Ratings { get; set; }
        public HashSet<Service> Services { get; set; } = new HashSet<Service>();

    }
}
