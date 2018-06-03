using E_Conc.Models;
using E_Conc.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace E_Conc.Services
{
    public class SmsService : ISmsService
    {
        public SmsSettings _smsSettings { get; }

        public SmsService(IOptions<SmsSettings> smsSettings)
        {
            _smsSettings = smsSettings.Value;
        }

        public async Task SendSmsAsync(string number, string message)
        {
            TwilioClient.Init(_smsSettings.SID, _smsSettings.auth_token);

            await MessageResource.CreateAsync(
                new PhoneNumber(number),
                from: _smsSettings.from_number,
                body: message
                );
        }
    }
}