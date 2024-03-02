using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Website
    {
        public int WebsiteId { get; set; }

        public string Category { get; set; }
        public string SubCategory { get; set; }

        public string OtherCategory { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string PublicUrl { get; set; }
        public string LogoImage { get; set; }
        public string PersonalPhoto { get; set; }
        public string NamewithDesignation { get; set; }
        public string CallingNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string FullAddress { get; set; }
        public string SmsNumber { get; set; }

        public string Designation { get; set; }
        public string Slautation { get; set; }

        public string Email { get; set; }

        public string WebsiteUrl { get; set; }






        #region FollwMe

        public string facebook { get; set; }
        public string Instagram { get; set; }
        public string Linkdin { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }

        #endregion FollwMe




        #region Services/Products
        public string ProductOrServiceName { get; set; }
       

        public ICollection<GalleryImages> Images { get; set; }
        public string QrPhoto { get; set; }

        public string PrimaryBg { get; set; }
        public string SecondryBg { get; set; }


        public string UrlName { get; set; }

        public string CustomCss { get; set; }


        public bool IsSCGT { get; set; }
        public bool IsMBC { get; set; }
        public bool IsBNI { get; set; }
        public bool IsMCC { get; set; }


        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        //public int SliderId { get; set; }


        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public List<Seo> Seos { get; set; }

        public List<AboutUs> AboutUs { get; set; }
        public List<WhyChooseUs> WhyChooseUs { get; set; }
        public List<GetAppointment> GetAppointments { get; set; }
        public List<Couter> Couters { get; set; }

         public List<Testimonial> Testimonials { get; set; }
         public List<Customization> Customizations { get; set; }

        #endregion

        public ICollection<Click> Clicks { get; set; } = new List<Click>();


    }

}
