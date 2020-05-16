using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System.Threading.Tasks;
#nullable disable

namespace Wagering.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _config;

        public EmailSender(EmailConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Plug in your email service here to send an email.
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("TEST SMTP", "Enter_Sender_EmailAdress"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            using var client = new SmtpClient();
            client.Connect(_config.SmtpServer, _config.SmtpPort);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate("Enter_Sender_EmailAdress", "Enter_Sender_EmailAdress_Password");
            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }
}
