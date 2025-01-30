using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHotelApp.Domain.Entities
{
    public sealed class Guests
    {
        public Guests()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string? IdentityNumber { get; set; }
        public string? eMail { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
