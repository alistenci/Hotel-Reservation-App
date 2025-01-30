namespace eHotelApp.Application.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string Email, string Subject, string HtmlMessage);
    }
}
