using eHotelApp.Domain.Entities;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eHotelApp.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<FloorRooms> FloorRoomss { get; set; }
        public DbSet<Guests> Guests { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<RoomInstance> RoomInstances { get; set; }
        public DbSet<HotelRooms> Rooms { get; set; }
        public DbSet<RoomType> RoomTypess { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserClaim<Guid>>(); // Identity kütüphanesindeki kullanılmayan classları ignore ettik.
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // IEntityTypeConfiguration interfacesini uygulayabilmek için bu interfacenin implement edildiği katmanı burada belirtmek zorundayız.
        }
    }
}
