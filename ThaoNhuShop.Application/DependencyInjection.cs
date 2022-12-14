using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ThaoNhuShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // services.AddSingleton<IAuthenticationCommandService, AuthenticationCommandService>();
            // services.AddSingleton<IAuthenticationQueryService, AuthenticationQueryService>();
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}