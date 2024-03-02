using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }

        public string Fullname { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }

        public string Photo { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
