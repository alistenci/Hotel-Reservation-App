using eHotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHotelApp.Infrastructure.Configurations
{
    internal sealed class ReservationsConfiguration : IEntityTypeConfiguration<Reservations>
    {
        public void Configure(EntityTypeBuilder<Reservations> builder)
        {
            
        }
    }
}
