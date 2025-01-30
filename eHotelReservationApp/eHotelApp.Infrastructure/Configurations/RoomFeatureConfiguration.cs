using eHotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHotelApp.Infrastructure.Configurations
{
    internal sealed class RoomFeatureConfiguration : IEntityTypeConfiguration<RoomFeature>
    {
        public void Configure(EntityTypeBuilder<RoomFeature> builder)
        {
            builder.Property(p => p.FeatureName).HasColumnType("varchar(50)");
            //builder.HasKey(k => new { k.Id });
        }
    }
}
