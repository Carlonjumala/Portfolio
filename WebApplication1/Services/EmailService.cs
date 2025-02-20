using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string name, string email, string message)
        {
            var smtpServer = _config["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_config["EmailSettings:SmtpPort"]);
            var smtpUsername = _config["EmailSettings:SmtpUsername"];
            var smtpPassword = _config["EmailSettings:SmtpPassword"];
            var fromEmail = _config["EmailSettings:FromEmail"];
            var toEmail = _config["EmailSettings:ToEmail"];

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = "New Contact Form Submission",
                Body = $"<h3>New Contact Form Message</h3>" +
                       $"<p><strong>Name:</strong> {name}</p>" +
                       $"<p><strong>Email:</strong> {email}</p>" +
                       $"<p><strong>Message:</strong></p>" +
                       $"<p>{message}</p>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            using var smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
