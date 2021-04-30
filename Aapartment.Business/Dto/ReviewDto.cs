using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Dto
{
    public class  ReviewDto
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public int UserId { get; set; }
        public int ApartmentId { get; set; }
    }
}
