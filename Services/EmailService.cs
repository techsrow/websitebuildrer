using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebsiteBuilder.Models;
using WebsiteBuilder.Services;

namespace WebsiteBuilder.Servicesx
{
    public class EmailService: IEmailService
    {
        private readonly IOptions<EmailSettings> _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = _emailSettings.Value.SmtpServer;
                smtpClient.Port = _emailSettings.Value.Port;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.Value.Username, _emailSettings.Value.Password);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_emailSettings.Value.FromAddress);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(toEmail);

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }

}
