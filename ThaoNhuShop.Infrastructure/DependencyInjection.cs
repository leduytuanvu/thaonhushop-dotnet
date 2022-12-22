
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ThaoNhuShop.Application.Common.Interfaces.Authentication;
using ThaoNhuShop.Application.Common.Interfaces.Persistence;
using ThaoNhuShop.Application.Common.Interfaces.Services.DateTimeProvider;
using ThaoNhuShop.Infrastructure.Authentication;
using ThaoNhuShop.Infrastructure.Persistence;
using ThaoNhuShop.Infrastructure.Persistence.Interceptors;
using ThaoNhuShop.Infrastructure.Services;

namespace ThaoNhuShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuth(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<IBrandRepository, BrandRepository>();
            
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            // CONFIGURE JWT SETTING
            services.AddSingleton(Options.Create(jwtSettings));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            // CONFIGURE JWT AUTHENTICATION
            services
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}