using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Services
{
    public interface  IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
