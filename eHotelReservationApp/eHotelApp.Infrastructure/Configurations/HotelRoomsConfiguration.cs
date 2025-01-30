using eHotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHotelApp.Infrastructure.Configurations
{
    internal sealed class HotelRoomsConfiguration : IEntityTypeConfiguration<HotelRooms>
    {
        public void Configure(EntityTypeBuilder<HotelRooms> builder)
        {
            builder.Property(p => p.RoomName).HasColumnType("varchar(50)");
            builder.Property(p => p.Description).HasColumnType("varchar(500)");
        }
    }
}
