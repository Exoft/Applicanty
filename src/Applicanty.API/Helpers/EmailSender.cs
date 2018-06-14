using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Applicanty.API.Helpers
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string message)
        {
            string toEmail = string.IsNullOrEmpty(email)
                             ? _emailSettings.ToEmail
                             : email;

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.FromEmail, "Applicanty")
            };

            mail.To.Add(new MailAddress(toEmail));

            mail.Subject = "Applicanty Management System - " + subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain))
            {
                smtp.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}