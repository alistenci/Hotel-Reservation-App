using eHotelApp.Domain.Entities;
using eHotelApp.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eHotelApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)  // IConfiguration uygulamanın yapılandırma ayarlarına erişmek için kullanılır. Veri tabanı bağlantı dizeleri vs.
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreServer"));
            });

            services.AddIdentityCore<AppUser>(action =>
            {
                //action.Password.RequiredLength = 1;
                action.Password.RequireUppercase = false;
                action.Password.RequireLowercase = false;
                action.Password.RequireNonAlphanumeric = false;
                action.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

            services.Scan(action =>
            {
                action.FromAssemblies(typeof(DependencyInjection).Assembly).
                AddClasses(publicOnly: false).
                UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip).
                AsImplementedInterfaces().
                WithScopedLifetime();
            });

            return services;

        }
    }
}
