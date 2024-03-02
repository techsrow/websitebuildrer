using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WebsiteBuilder.Models
{
    public class SmsService
    {

        private readonly TwilioSettings _twilioSettings;

        public SmsService(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
            TwilioClient.Init(_twilioSettings.AccountSid, _twilioSettings.AuthToken);
        }
        public void SendSms(string to, string message)
        {
            var phoneNumber = new PhoneNumber(to);
             
            MessageResource.Create(
                to: phoneNumber,
                from: new PhoneNumber(_twilioSettings.PhoneNumber),
                body: message
            );
        }

    }
}
