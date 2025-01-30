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
    internal sealed class GuestsConfiguration : IEntityTypeConfiguration<Guests>
    {
        public void Configure(EntityTypeBuilder<Guests> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            builder.Property(p => p.IdentityNumber).HasColumnType("varchar(11)");
            builder.HasIndex(p => p.IdentityNumber).IsUnique();
            builder.Property(p => p.eMail).HasColumnType("varchar(50)");
            builder.HasIndex(p => p.eMail).IsUnique();
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar(50)");
            builder.HasIndex(p => p.PhoneNumber).IsUnique();
        }
    }
}
