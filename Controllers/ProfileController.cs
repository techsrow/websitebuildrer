//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebsiteBuilder.Models;
//using WebsiteBuilder.Services;
//using WebsiteBuilder.ViewModels;

//namespace WebsiteBuilder.Controllers
//{
//    [Authorize]
//    public class ProfileController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly ILogger<LoginViewModel> _logger;

//        private readonly WebsiteConstraintService _websiteConstraintService;

//        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }
//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Create(BussinessProfile model)
//        {
//            if (ModelState.IsValid)
//            {
//                var profile = new BussinessProfile
//                {
//                    Phone = model.Phone,
//                    Email = model.Email,
//                    BusinessName = model.BusinessName,
//                    Address = model.Address,
//                    MapUrl = model.MapUrl,
//                    Instagram = model.Instagram,
//                    Meta = model.Meta,
//                    XoldTwitter = model.XoldTwitter,
//                    youtube = model.youtube,
//                    github = model.github,
//                    LinkedIn = model.LinkedIn,
//                    // Map other properties as needed
//                };

//                var websiteId = await GetWebsiteIdForCurrentUser(); // Use async/await here
//                if (websiteId != null)
//                {
//                    profile.WebsiteId = websiteId.Value;
//                    _context.BussinessProfiles.Add(profile);
//                    await _context.SaveChangesAsync();

//                    return RedirectToAction("Index", "Home");
//                }
//                else
//                {
//                    // Handle the case where the user doesn't have a website
//                    // You can return an error view or redirect to an error page
//                    return View("Error");
//                }
//            }

//            return View(model);
//        }

//        public async Task<int?> GetWebsiteIdForCurrentUser()
//        {
//            // Get the currently logged-in user
//            var user = await _userManager.GetUserAsync(User);

//            if (user != null)
//            {
//                // Query the database to find the WebsiteId associated with the user
//                var websiteId = _context.Websites
//                    .Where(w => w.UserId == user.Id)
//                    .Select(w => (int?)w.WebsiteId)
//                    .FirstOrDefault();

//                return websiteId;
//            }

//            return null; // User is not logged in or doesn't have an associated website
//        }

//        // Action to edit an existing slider
//        //public IActionResult Edit(int id)
//        //{
//        //    var model = _context.BussinessProfiles.FirstOrDefault(s => s.BussinessProfileId == id);
//        //    if (model == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var profile = new BussinessProfile
//        //    {
//        //        Phone = model.Phone,
//        //        Email = model.Email,
//        //        BusinessName = model.BusinessName,
//        //        Address = model.Address,
//        //        MapUrl = model.MapUrl,
//        //        Instagram = model.Instagram,
//        //        Meta = model.Meta,
//        //        XoldTwitter = model.XoldTwitter,
//        //        youtube = model.youtube,
//        //        github = model.github,
//        //        LinkedIn = model.LinkedIn,
//        //        // Map other properties as needed
//        //    };

//        //    return View(model);
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> Edit(int id, Slider model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        var slider = _context.Sliders.FirstOrDefault(s => s.SliderId == id);
//        //        if (slider == null)
//        //        {
//        //            return NotFound();
//        //        }

//        //        // Update the slider properties
//        //        slider.SliderTitle = model.SliderTitle;
//        //        // Update other properties as needed

//        //        _context.Sliders.Update(slider);
//        //        await _context.SaveChangesAsync();

//        //        return RedirectToAction("Index", "Home"); // Redirect to a success page
//        //    }

//        //    return View(model);
//        //}

//        //// Action to delete a slider
//        //[HttpGet]
//        //public IActionResult Delete(int id)
//        //{
//        //    var slider = _context.Sliders.FirstOrDefault(s => s.SliderId == id);
//        //    if (slider == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(slider);
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> Delete(int id)
//        //{
//        //    var slider = _context.Sliders.FirstOrDefault(s => s.SliderId == id);
//        //    if (slider != null)
//        //    {
//        //        _context.Sliders.Remove(slider);
//        //        await _context.SaveChangesAsync();
//        //    }

//        //    return RedirectToAction("Index", "Home"); // Redirect to a success page
//        //}

//        // Helper method to get the website ID for the currently logged-in user
//        //private async Task<int?> GetWebsiteIdForCurrentUser()
//        //{
//        //    // Get the currently logged-in user
//        //    var user = await _userManager.GetUserAsync(User);

//        //    // Check if the user exists and has a website
//        //    if (user != null && user.Website != null)
//        //    {
//        //        return user.Website.WebsiteId;
//        //    }

//        //    return null; // User doesn't have a website
//        //}


//    }
//}
