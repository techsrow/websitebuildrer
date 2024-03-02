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
    [Authorize]
    public class SeoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly WebsiteConstraintService _websiteConstraintService;
        public SeoController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context, WebsiteConstraintService websiteConstraintService)
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
            var seo = await _context.Seos
                .Where(s => s.WebsiteId == websiteId)
                .ToListAsync();

            // Optionally, you can pass the services to a view or return as JSON
            return View(seo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seo seo, IFormFile imageFile)

        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the user's id

                // Find the user's website
                var userWebsite = await _context.Websites
                    .FirstOrDefaultAsync(w => w.UserId == userId);

                // Associate the service with the user's website
                seo.WebsiteId = userWebsite?.WebsiteId ?? 0;

                var imageName = "sitemap.xml";
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));
                }

                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imageName);
                await using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                seo.SiteMap = $"/wwwroot/{imageName}";

                _context.Add(seo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seo);
        }
    }
}
