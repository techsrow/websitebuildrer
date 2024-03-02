using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Helpers
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string RequiredEmail { get; }

        public EmailRequirement(string requiredEmail)
        {
            RequiredEmail = requiredEmail;
        }
    }
}
