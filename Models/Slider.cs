using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Slider
    {
        public int SliderId { get; set; }
       

        public string SliderTitle { get; set; }
        public string SliderImage { get; set; }
        public string SliderShortDescription { get; set; }
        public string BtnText { get; set; }

        public string BtnLink { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }



    }
}
