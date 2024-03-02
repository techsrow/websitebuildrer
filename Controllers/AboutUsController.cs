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
    public class AboutUsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly WebsiteConstraintService _websiteConstraintService;
        public AboutUsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context, WebsiteConstraintService websiteConstraintService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _websiteConstraintService = websiteConstraintService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find the user's website
            var userWebsite = await _context.Websites
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (userWebsite == null)
            {
                // Handle the case where the user doesn't have a website
                return NotFound("User does not have a website.");
            }

            var websiteId = userWebsite.WebsiteId;

            // Retrieve services associated with the user's website
            var aboutus = await _context.AboutUs
                .Where(s => s.WebsiteId == websiteId)
                .ToListAsync();

            // Optionally, you can pass the services to a view or return as JSON
            return View(aboutus);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutUs about, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the user's id

                // Find the user's website
                var userWebsite = await _context.Websites
                    .FirstOrDefaultAsync(w => w.UserId == userId);

                // Associate the service with the user's website
                about.WebsiteId = userWebsite?.WebsiteId ?? 0;

                var imageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/about")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/about"));
                }

                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/about", imageName);
                await using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                about.AboutImage = $"/img/about/{imageName}";
                //if (imageFile != null && imageFile.Length > 0)
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        await imageFile.CopyToAsync(memoryStream);
                //        slider.SliderImage = Convert.ToBase64String(memoryStream.ToArray());
                //    }
                //}

                _context.Add(about);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }
    }
}
