using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebsiteBuilder.Data
{
    public static class RolesSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create roles if they don't exist
            await CreateRole(roleManager, "Admin");
            await CreateRole(roleManager, "User");
            await CreateRole(roleManager, "SuperAdmin");
            // Add more roles as needed
        }

        private static async Task CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            // Check if the role doesn't exist
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                // Create the role
                var role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }
    }
}
