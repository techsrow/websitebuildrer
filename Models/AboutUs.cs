using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class AboutUs
    {
        public int AboutUsId { get; set; }
        public string AboutName { get; set; }
        public string AboutImage { get; set; }
        public string AboutDescription { get; set; }
        public string AboutShortDesc { get; set; }                                          

        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
