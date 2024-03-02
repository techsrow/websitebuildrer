using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;
using WebsiteBuilder.ViewModels;

namespace WebsiteBuilder.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
      
        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }


        [HttpGet]
        [Route("/{publicUrl}")]
        public IActionResult Index(string publicUrl)
        
        {
            
            //var website = _context.Websites.Find(publicUrl);
            var website = _context.Websites.Include(g => g.Images).Include(s=>s.Sliders).Include(a=>a.AboutUs).SingleOrDefault(w => w.PublicUrl == publicUrl);
            var about = _context.AboutUs.SingleOrDefault(w => w.Website.PublicUrl == publicUrl);
            var slider = _context.Sliders.Where(s => s.Website.PublicUrl == publicUrl).ToList();
            var whychooseus = _context.WhyChooseUs.Where(w => w.Website.PublicUrl == publicUrl).ToList();
            var services = _context.Services.Where(s => s.Website.PublicUrl == publicUrl).ToList();
            var testimonial = _context.Testimonials.Where(s => s.Website.PublicUrl == publicUrl).ToList();

            var getAppointment = _context.GetAppointments.SingleOrDefault(w => w.Website.PublicUrl == publicUrl);

            var seo = _context.Seos.SingleOrDefault(w => w.Website.PublicUrl == publicUrl);

            var theme = _context.Customizations.SingleOrDefault(w => w.Website.PublicUrl == publicUrl);
            if (theme == null)
            {
                // Handle the case where no customization data is found
                theme = new Customization
                {
                    // Example default values
                    ThemeColor = "#212529", // Default white theme color
                    SubheadingColor = "#ffffff",
                    TextColor = "#000",
                    headingColor = "#000000"
                    // Default black subheading color
                                                // You can add more default values as needed
                };
                // You can provide default values or handle it as needed
                theme = new Customization();
            }
            var counter = _context.Couters.Where(w => w.Website.PublicUrl == publicUrl).ToList();

            //var websiteid = _context.Websites.FirstOrDefault(w => w.PublicUrl == publicUrl);
            int? websiteId = GetWebsiteIdByPublicUrl(publicUrl);

            if (website == null)
            {
                //return NotFound(); // Handle the case where the website is not found
                return RedirectToAction("Error", "Home");

            }

            //string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4();

            if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                // Convert IPv6 to IPv4
                ipAddress = ipAddress.MapToIPv4();
            }

            string ipAddress4 = ipAddress.ToString();

            bool isUniqueClick = _context.Clicks.Any(c=>c.WebsiteId == website.WebsiteId && c.IpAddress == ipAddress.ToString());

            _context.Clicks.Add(new Click { WebsiteId = website.WebsiteId, IpAddress = ipAddress.ToString(), Timestamp = DateTime.UtcNow });
            _context.SaveChanges();

            //var entity = _context.Websites.FirstOrDefault(e => e.PublicUrl == publicUrl);

            // if(entity !=null)
            //{
            //    // Retrieve the website with the specified public URL
            //    var website = _context.Websites.SingleOrDefault(w => w.PublicUrl == publicUrl);


            //    var slider = _context.Sliders.Where(w => w.WebsiteId == website.WebsiteId).ToList();


            //    var viewModel = new WebsiteViewModel
            //    {
            //        _sliders = slider,
            //        _website = website
            //    };



            //    return View(viewModel);
            //}

            //else
            //{
            //    return RedirectToAction("Error", "Home");
            //}


            // Retrieve the website with the specified public URL
            //var website = _context.Websites.Include(g=>g.Images).SingleOrDefault(w => w.PublicUrl == publicUrl);

            //if (website == null)
            //{
            //    // Handle the case where the public URL doesn't exist
            //    return RedirectToAction("Error", "Home");
            //}
            WebsiteViewModel model = new WebsiteViewModel
            {
                _website = website,
                _Aboutus = about,
                _sliders = slider,
                _whyChooseUs = whychooseus,
                _Service  = services,
                _GetAppointment = getAppointment,
                _Testimonial = testimonial,
                _Seo = seo,
                _customization = theme,
                _Counter = counter




            };

            return View(model);
        }



       
        public IActionResult Error()
        {
            return View();
        }


        //public IActionResult HomePage()
        //{
        //    return View();
        //}
        public IActionResult HomePage()
        {

           
           

            return View();

        }

            public int? GetWebsiteIdByPublicUrl(string publicUrl)
        {
            // Assuming _context is your ApplicationDbContext
            var website = _context.Websites.FirstOrDefault(w => w.PublicUrl == publicUrl);

            return website?.WebsiteId;
        }


        private bool IsUniqueIpAddress(int websiteId, Click ipAddress)
        {
            // Check if there is any record in the database with the same IP address for this website
            return !_context.Clicks.Any(v => v.WebsiteId == websiteId && v.IpAddress == ipAddress.ToString());
        }

        private void RecordVisit(int websiteId, Click ipAddress)
        {
            // Record the visit in the database
            var visit = new Click
            {
                WebsiteId = websiteId,
                IpAddress = ipAddress.ToString(),
                Timestamp = DateTime.UtcNow,
                
                // Additional properties as needed
            };

            _context.Clicks.Add(visit);
            _context.SaveChanges();
        }

    }


}