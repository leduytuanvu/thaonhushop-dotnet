
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThaoNhuShop.Application.Common.Interfaces.Authentication;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Application.Common.Interfaces.Services.DateTimeProvider;
using ThaoNhuShop.Infrastructure.Authentication;
using ThaoNhuShop.Infrastructure.Persistence;
using ThaoNhuShop.Infrastructure.Services;

namespace ThaoNhuShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}