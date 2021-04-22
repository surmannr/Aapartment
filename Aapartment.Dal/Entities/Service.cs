using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Dal.Entities
{
    [Owned]
    public class Service
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
