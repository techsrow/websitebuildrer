using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class ApplicationUser : IdentityUser
    {
        // You can add custom user properties here if needed

        public int? WebsiteId { get; set; }
       
        public Website Website { get; set; } = null;

       



        // Add any other user properties

    }
}
