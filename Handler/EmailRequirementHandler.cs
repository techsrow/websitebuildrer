using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebsiteBuilder.Helpers;

namespace WebsiteBuilder.Handler
{
    public class EmailRequirementHandler : AuthorizationHandler<EmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            var userEmail = context.User.FindFirst(ClaimTypes.Email)?.Value;

            if (userEmail != null && userEmail.Equals(requirement.RequiredEmail, StringComparison.OrdinalIgnoreCase))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

}
