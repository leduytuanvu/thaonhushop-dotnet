using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ThaoNhuShop.Application.Common.Behaviors;

namespace ThaoNhuShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // services.AddSingleton<IAuthenticationCommandService, AuthenticationCommandService>();
            // services.AddSingleton<IAuthenticationQueryService, AuthenticationQueryService>();
            
            // ADD MEDIATR
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            // ADD BEHAVIOR VALIDATION
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}