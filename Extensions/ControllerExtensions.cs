using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebsiteBuilder.Models;

namespace WebsiteBuilder.Extensions
{
    public static class ControllerExtensions
    {
        public static async Task<ApplicationUser> GetUserAsync(this Controller controller, UserManager<ApplicationUser> userManager)
        {
            ClaimsPrincipal user = controller.User;

            // Get the user's unique identifier (typically, the user's ID)
            Claim userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                string userId = userIdClaim.Value;

                // Use the UserManager to get user details
                return await userManager.FindByIdAsync(userId);
            }

            return null; // User not found
        }
    }
  
}
