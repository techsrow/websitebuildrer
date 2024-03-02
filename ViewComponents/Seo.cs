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
    [ViewComponent(Name = "Seo")]
    
   
    public class Seo : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly WebsiteConstraintService _websiteConstraintService;
        public Seo(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context, WebsiteConstraintService websiteConstraintService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _websiteConstraintService = websiteConstraintService;
        }


        [Route("/{publicUrl}")]
        public async Task<IViewComponentResult> InvokeAsync(string publicUrl)
        {
            var seo = _context.Seos.SingleOrDefault(w => w.Website.PublicUrl == publicUrl);


            WebsiteViewModel model = new WebsiteViewModel
            {
                _Seo = seo,
               



            };

            return View(model);
        }
    }
}
