using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ThaoNhuShop.Api.Common.Errors;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.API
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Add services to the container
            services.AddControllers();

            // ADD PROBLEM DETAILS FACTORY
            services.AddSingleton<ProblemDetailsFactory, ThaoNhuShopProblemDetailsFactory>();

            // ADD AUTOMAPPER
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // ADD DBCONTEXT WITH SINGLETON
            // services.AddDbContext<ThaoNhuShopDbContext>(
            //    options => options.UseSqlServer(
            //        "name=ConnectionStrings:ThaoNhuShop",
            //        b => b.MigrationsAssembly("ThaoNhuShop.Api")
            //    ), ServiceLifetime.Singleton
            // );

            services.AddDbContext<ThaoNhuShopDbContext>(options =>
                options.UseNpgsql(
                    "name=ConnectionStrings:ThaoNhuShop",
                    b => b.MigrationsAssembly("ThaoNhuShop.Api")
                ), ServiceLifetime.Singleton
            );

            // SET UP CORS
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            return services;
        }
    }

}