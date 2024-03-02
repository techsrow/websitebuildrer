using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;
using WebsiteBuilder.ViewModels;

namespace WebsiteBuilder.Services
{
    public class WebsiteConstraintService
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
       

        public WebsiteConstraintService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context)
        {
            _context = context;
        }

        public bool UserHasWebsite(string userId)
        {
            // Check if the user already has a website
            return _context.Websites.Any(w => w.UserId == userId);
        }

        
    }
}
