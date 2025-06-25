using System.Net;
using System.Net.Mail;

namespace PasswordResetAPI.Services
{
    public class EmailService
    {
        private readonly IConfiguration conf;
        public EmailService(IConfiguration conf)
        {
            this.conf = conf;
        }
        public async Task SendEmail(string toEmail, string link)
        {
            // Ensure modern TLS
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var fromEmail = conf["EmailSettings:FromEmail"];
            var smtpServer = conf["EmailSettings:SmtpServer"]; // "smtp.gmail.com"
            var port = int.Parse(conf["EmailSettings:Port"]);  // 587
            var username = conf["EmailSettings:Username"];
            var password = conf["EmailSettings:Password"];     // ← From env variable

            var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = "Password Reset",
                Body = $"Click the link to reset your password: {link}",
                IsBodyHtml = true
            };

            using var smtp = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            await smtp.SendMailAsync(message);
        }
    }
}