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

namespace WebsiteBuilder.ViewComponents
{
    [ViewComponent(Name = "LeftSideBar")]
    public class LeftSideBar : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly WebsiteConstraintService _websiteConstraintService;

        public LeftSideBar(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context, WebsiteConstraintService websiteConstraintService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _websiteConstraintService = websiteConstraintService;
        }

       // public async Task<IViewComponentResult> InvokeAsync()
       // {
       //     var user = await _userManager.GetUserAsync((ClaimsPrincipal)User);
       //     var userWebsite = _context.Websites
       //.FirstOrDefault(w => w.UserId == user.Id);

       //     if (userWebsite == null)
       //     {
       //         return NotFound(); // Handle the case where the user has no websites
       //     }
       //     return View(userWebsite);
       // }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync((ClaimsPrincipal)User);
            var userWebsite = _context.Websites
                .FirstOrDefault(w => w.UserId == user.Id);

            if (userWebsite == null)
            {

                  return Content("It appears that your website hasn't been created yet. Take the initiative and build your own site now!"); // Use NotFound() instead of NotFoundResult()
                
            }

            return View(userWebsite);
        }


    }
}
