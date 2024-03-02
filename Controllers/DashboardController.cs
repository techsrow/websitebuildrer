using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebsiteBuilder.Extensions;
using WebsiteBuilder.Models;
using WebsiteBuilder.Services;
using WebsiteBuilder.ViewModels;

namespace WebsiteBuilder.Controllers
{

   
    
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly WebsiteConstraintService _websiteConstraintService;
        public DashboardController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context, WebsiteConstraintService websiteConstraintService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _websiteConstraintService = websiteConstraintService;
        }


        [Authorize]
    
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            // Fetch the first website associated with the current user
            var userWebsite = _context.Websites
                .FirstOrDefault(w => w.UserId == userId);
            var click = _context.Websites.Include(c => c.Clicks).Where(w=>w.UserId == userId).Count();

            if (userWebsite == null)
            {
                return RedirectToAction("NotFound"); // Handle the case where the user has no websites
            }

            AdminViewModel viewModel = new AdminViewModel
            {
                User = userId,
                Website = userWebsite,
                Click = click

            };
            return View(viewModel);
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
