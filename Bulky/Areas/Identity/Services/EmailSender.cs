using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace YourRazorPagesApp.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _sendGridApiKey; // Replace with your SendGrid API key.

        public EmailSender(string sendGridApiKey)
        {
            _sendGridApiKey = sendGridApiKey;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("your_sender_email@example.com", "Your Name"); // Replace with your sender email and name
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

            await client.SendEmailAsync(msg);
        }
    }
}
