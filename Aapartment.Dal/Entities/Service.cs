using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
