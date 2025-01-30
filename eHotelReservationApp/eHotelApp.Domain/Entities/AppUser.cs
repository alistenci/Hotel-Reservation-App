using Microsoft.AspNetCore.Identity;

namespace eHotelApp.Domain.Entities
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? FullName => string.Join(" ", FirstName, LastName);
        public string? Role { get; set; }
        public string? VerificationCode { get; set; }
        public DateTime VerificationExpiry { get; set; }
    }
}
