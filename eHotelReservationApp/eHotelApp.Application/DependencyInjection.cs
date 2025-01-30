using Microsoft.Extensions.DependencyInjection;

namespace eHotelApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // AutoMapper için konfigürasyon
            services.AddAutoMapper(typeof(DependencyInjection));

            // MediatR için konfigürasyon
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services; // Hizmetleri döndürün
        }
    }

}