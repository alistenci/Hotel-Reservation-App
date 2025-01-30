using eHotelApp.Application.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace eHotelApp.Infrastructure.Services
{
    public sealed class EmailSender(IConfiguration configuration) : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var mailMessage = new MailMessage(configuration["EmailSettings:FromEmail"] ?? "", email))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = htmlMessage;
                mailMessage.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient(configuration["EmailSettings:SmtpServer"]))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = int.Parse(configuration["587"] ?? "587"); // Örneğin: 587
                    smtpClient.Credentials = new NetworkCredential(configuration["EmailSettings:Username"], configuration["EmailSettings:Password"]);

                    try
                    {
                        await smtpClient.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        // Hata loglama
                        Console.WriteLine($"Email gönderme hatası: {ex.Message}");
                    }
                }
            }
        }
    }
}