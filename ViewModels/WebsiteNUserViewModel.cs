using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;

namespace WebsiteBuilder.ViewModels
{
    public class WebsiteNUserViewModel
    {
        public List<ApplicationUser> User { get; set; }
        public List<Website> Websites { get; set; }
    }
}
