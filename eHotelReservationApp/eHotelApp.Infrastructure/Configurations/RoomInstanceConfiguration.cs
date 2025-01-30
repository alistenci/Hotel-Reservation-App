using eHotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHotelApp.Infrastructure.Configurations
{
    internal sealed class RoomInstanceConfiguration : IEntityTypeConfiguration<RoomInstance>
    {
        public void Configure(EntityTypeBuilder<RoomInstance> builder)
        {
            
        }
    }
}
