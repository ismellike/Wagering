using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
#nullable disable

namespace Wagering.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _config.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("ismellike@live.com", "Wagering.gg (ismellike)"));
            msg.AddTo(new EmailAddress(email));
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);
            return client.SendEmailAsync(msg);
        }
    }
}
