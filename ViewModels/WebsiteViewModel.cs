using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;

namespace WebsiteBuilder.ViewModels
{
    public class WebsiteViewModel
    {
       public Website _website { get; set; }
        public List<Slider> _sliders { get; set; }
        public List<WhyChooseUs> _whyChooseUs { get; set; }

        public List<Service> _Service { get; set; }

        public AboutUs _Aboutus { get; set; }

        public GetAppointment _GetAppointment { get; set; }

        public List<Testimonial> _Testimonial { get; set; }


        public List<Couter> _Counter { get; set; }

        public Seo _Seo { get; set; }

        public Customization _customization { get; set; }
           





    }
}
