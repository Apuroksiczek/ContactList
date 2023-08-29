using Infrastructure.Authentication;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
