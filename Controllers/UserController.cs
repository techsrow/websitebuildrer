// UserController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;
using WebsiteBuilder.Services;
using WebsiteBuilder.Servicesx;
using WebsiteBuilder.ViewModels;

public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger<LoginViewModel> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IEmailService _emailSender;

    public UserController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, ApplicationDbContext context, IEmailService emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _context = context;
        _emailSender = emailSender;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("HomePage", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel user)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

            if (result.Succeeded)
            {
                var userM = await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
                _logger.LogInformation("User logged in.");
                return RedirectToAction("HomePage", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

        }
        return View(user);
    }

    [Authorize]
    public IActionResult ChangePassword()
    {
        return View();
    }
    [Authorize]
    public IActionResult ChangePasswordConfirmation()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("ChangePasswordConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found.");
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                // Generate a password reset token
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                // Create a password reset link
                var callbackUrl = Url.Action("ResetPassword", "User", new { userId = user.Id, token }, protocol: HttpContext.Request.Scheme);

                // Send the reset link via email
                // (Use your email service here)
                await _emailSender.SendEmailAsync(user.Email, "Password Reset", $"Click <a href='{callbackUrl}'>here</a> to reset your password.");

                return RedirectToAction("ForgotPasswordConfirmation");
            }

            // Display a message that the email is sent (for security reasons)
            return RedirectToAction("EmailNotFound");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult ForgotPasswordConfirmation()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ResetPassword(string userId, string token)
    {
        // Verify the token and userId
        // You can add validation here if needed

        var model = new ResetPasswordViewModel
        {
            UserId = userId,
            Token = token
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                // Reset the user's password
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                if (result.Succeeded)
                {
                    // Redirect to the login page or a password reset confirmation page
                    return RedirectToAction("ResetPasswordConfirmation");
                }

                // Display errors if the password reset fails
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                // Display a message that the user does not exist
                ModelState.AddModelError(string.Empty, "User not found.");
            }
        }

        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPasswordConfirmation()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync(); // Sign the user out
        return RedirectToAction("HomePage", "Home"); // Redirect to the home page or another page
    }


    [HttpGet]
    public IActionResult EmailNotFound()
    {
        return View();
    }
}

