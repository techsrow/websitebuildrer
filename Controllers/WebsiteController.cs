
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

[Authorize]
public class WebsiteController : Controller
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger<LoginViewModel> _logger;
    private readonly ApplicationDbContext _context;
    private readonly WebsiteConstraintService _websiteConstraintService;
    public WebsiteController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context,WebsiteConstraintService websiteConstraintService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _context = context;
        _websiteConstraintService = websiteConstraintService;
    }


    public bool UserHasWebsite(string userId)
    {
        return _context.Websites.Any(w => w.UserId == userId);
    }

    [Authorize] // Ensure the user is authenticated
    public IActionResult ListMyWebsites()
    {
        var userId = _userManager.GetUserId(User);

        // Fetch the first website associated with the current user
        var userWebsite = _context.Websites
            .FirstOrDefault(w => w.UserId == userId);

        if (userWebsite == null)
        {
            return NotFound(); // Handle the case where the user has no websites
        }

        return View(userWebsite);
    }

    public async Task<IActionResult> IndexAsync(string returnUrl = null)
    {
        var userId = _userManager.GetUserId(User);
        IdentityUser currentUser = await this.GetUserAsync(_userManager);

        if (currentUser == null)
        {
           return RedirectToAction("Login"); // Redirect to login if user is not authenticated
       }
        if (_websiteConstraintService.UserHasWebsite(userId))
        {

            var website = _context.Websites.ToList();
            // Redirect or display an error message
            return View(website);
        }
        return View();
    }
    [HttpGet]
    public IActionResult Create()
    {
        ViewData["UserId"] = User.Identity.Name;
      
        return View();
    }

   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Website website, IFormFile LogoImage, IFormFile PersonalPhoto, IFormFile QrPhoto, List<IFormFile> images)
    {
        if (ModelState.IsValid)


        {
            if (_context.Websites.Any(w => w.PublicUrl == website.PublicUrl))
            {
                ModelState.AddModelError("PublicUrl", "This URL already exists. Please choose a different one.");
                return View(website);
            }
            // Generate a public URL (you can customize this)
            website.PublicUrl = GeneratePublicUrl(website.PublicUrl);

            // Get the current user
            var userId = _userManager.GetUserId(User);


            //IdentityUser currentUser = await this.GetUserAsync(_userManager);

            //if (currentUser == null)
            //{
            //    return RedirectToAction("Login"); // Redirect to login if user is not authenticated
            //}

            //// Assign the current user to the website
            //website.UserId = currentUser.Id;

            if (userId == null)
            {
                return RedirectToAction("Login", "User"); // Redirect to login if user is not authenticated
            }

            if (_websiteConstraintService.UserHasWebsite(userId))
            {
                // Redirect or display an error message
                return RedirectToAction("AlreadyExist", "Website"); // Redirect to the user's existing website
            }

            // Assign the current user to the website
            // website.UserId = currentUser.Id;
            website.UserId = userId;
            if (LogoImage == null && PersonalPhoto == null)
            {
                ModelState.AddModelError("Image", "Product Image is required.");
                return View(website);
            }


            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/uploads/img"));
            }
            var mainLogoImageName = Guid.NewGuid() + Path.GetExtension(LogoImage.FileName);
            var mainPersonalPhotoName = Guid.NewGuid() + Path.GetExtension(PersonalPhoto.FileName);


            //Get url To Save
            var mainLogoImageSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img", mainLogoImageName);
            var mainPersonalPhotoSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img", mainPersonalPhotoName);

            //Get url To Save for Banner Image


            await using (var stream = new FileStream(mainLogoImageSavePath, FileMode.Create))
            {
                await LogoImage.CopyToAsync(stream);
            }

            await using (var stream = new FileStream(mainPersonalPhotoSavePath, FileMode.Create))
            {
                await PersonalPhoto.CopyToAsync(stream);
            }
            website.LogoImage = $"/uploads/img/{mainLogoImageName}";
            website.PersonalPhoto = $"/uploads/img/{mainPersonalPhotoName}";
            _context.Add(website);

            // User already has a website, handle accordingly (e.g., redirect)
            _context.Websites.Add(website);
                await _context.SaveChangesAsync();

            if (images != null)
            {
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/uploads/img"));
                }

                foreach (IFormFile item in images)
                {
                    //Set Key Name
                    var imageName = Guid.NewGuid() + Path.GetExtension(item.FileName);

                    //Get url To Save
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img", imageName);

                    await using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    var image = new GalleryImages()
                    {
                        WebsiteId = website.WebsiteId,
                        Img = $"/uploads/img/{imageName}"
                    };

                    _context.Add(image);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Confirm");
        }
        return View(website);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Website website, IFormFile LogoImage, IFormFile PersonalPhoto, IFormFile QrPhoto, List<IFormFile> images, int id)
    {
        if (id != website.WebsiteId)
        {
            return NotFound();
        }


        if (ModelState.IsValid)
        {
            try
            {
                // Get the current user
                var userId = _userManager.GetUserId(User);

                if (userId == null)
                {
                    return RedirectToAction("Login", "User"); // Redirect to login if the user is not authenticated
                }

                //// Check if the user has an existing website
                //if (!_websiteConstraintService.UserHasWebsite(userId))
                //{
                //    return RedirectToAction("Create", "Website"); // Redirect to create a website if the user doesn't have one
                //}

                // Get the existing website for the user
                var existingWebsite = _context.Websites.FirstOrDefault(w=>w.WebsiteId == id);

                //if (existingWebsite == null)
                //{
                //    return RedirectToAction("Create", "Website"); // Redirect to create a website if the user's website is not found
                //}

                // Update the website properties
                existingWebsite.Title = website.Title;
                existingWebsite.Content = website.Content;
                existingWebsite.PublicUrl = website.PublicUrl;
                existingWebsite.NamewithDesignation = website.NamewithDesignation;
                existingWebsite.CallingNumber = website.CallingNumber;
                existingWebsite.WhatsappNumber = website.WhatsappNumber;
                existingWebsite.FullAddress = website.FullAddress;
                existingWebsite.SmsNumber = website.SmsNumber;
                existingWebsite.Designation = website.Designation;
                existingWebsite.Slautation = website.Slautation;
                existingWebsite.Email = website.Email;
                existingWebsite.WebsiteUrl = website.WebsiteUrl;
                existingWebsite.facebook = website.facebook;
                existingWebsite.Instagram = website.Instagram;
                existingWebsite.Linkdin = website.Linkdin;
                existingWebsite.Twitter = website.Twitter;
                existingWebsite.Youtube = website.Youtube;
                existingWebsite.ProductOrServiceName = website.ProductOrServiceName;
                existingWebsite.AboutUs = website.AboutUs;
                existingWebsite.PrimaryBg = website.PrimaryBg;
                existingWebsite.SecondryBg = website.SecondryBg;
                existingWebsite.CustomCss = website.CustomCss;
                existingWebsite.IsSCGT = website.IsSCGT;
                existingWebsite.IsMBC = website.IsMBC;
                existingWebsite.IsBNI = website.IsBNI;
                existingWebsite.IsMCC = website.IsMCC;



                // Handle image uploads, similar to the create action
                if (LogoImage != null)
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/uploads/img"));
                    }
                    var mainLogoImageName = Guid.NewGuid() + Path.GetExtension(LogoImage.FileName);



                    //Get url To Save
                    var mainLogoImageSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img", mainLogoImageName);


                    //Get url To Save for Banner Image


                    await using (var stream = new FileStream(mainLogoImageSavePath, FileMode.Create))
                    {
                        await LogoImage.CopyToAsync(stream);
                    }


                    existingWebsite.LogoImage = $"/uploads/img/{mainLogoImageName}";

                }

                if (PersonalPhoto != null)
                {
                    // Handle PersonalPhoto update

                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/uploads/img"));
                    }

                    var mainPersonalPhotoName = Guid.NewGuid() + Path.GetExtension(PersonalPhoto.FileName);


                    //Get url To Save

                    var mainPersonalPhotoSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img", mainPersonalPhotoName);

                    //Get url To Save for Banner Image



                    await using (var stream = new FileStream(mainPersonalPhotoSavePath, FileMode.Create))
                    {
                        await PersonalPhoto.CopyToAsync(stream);
                    }

                    existingWebsite.PersonalPhoto = $"/uploads/img/{mainPersonalPhotoName}";
                }


                if (images != null)
                {
                    // Handle gallery images update
                    // ...

                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/uploads/img"));
                    }

                    foreach (IFormFile item in images)
                    {
                        //Set Key Name
                        var imageName = Guid.NewGuid() + Path.GetExtension(item.FileName);

                        //Get url To Save
                        var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/img", imageName);

                        await using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                        }

                        var image = new GalleryImages()
                        {
                            WebsiteId = website.WebsiteId,
                            Img = $"/uploads/img/{imageName}"

                        };

                        _context.Add(image);
                    }
                }

                // Update other properties as needed

                _context.Websites.Update(existingWebsite);
                await _context.SaveChangesAsync();




            }


            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteExists(website.WebsiteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Index", "Dashboard");

           
        }
        return View(website);
    }

    private string GeneratePublicUrl(string title)
    {
        // Replace spaces with hyphens and make the URL lowercase
        return title.Replace(" ", "-").ToLower();
    }


    [AllowAnonymous]

    [HttpGet]
    [Route("Website/Public/{publicUrl}")]
    public IActionResult Public(string publicUrl)
    {
        // Retrieve the website with the specified public URL
        var website = _context.Websites.SingleOrDefault(w => w.PublicUrl == publicUrl);

        if (website == null)
        {
            // Handle the case where the public URL doesn't exist
            return NotFound();
        }

        return View(website);
    }


    public ActionResult AlreadyExist()
    {
        return View();
    }


    private bool WebsiteExists(int id)
    {
        return _context.Websites.Any(e => e.WebsiteId == id);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var website = await _context.Websites.FirstOrDefaultAsync(i => i.WebsiteId == id);
        if (website == null)
        {
            return NotFound();
        }

        return View(website);
    }

}
