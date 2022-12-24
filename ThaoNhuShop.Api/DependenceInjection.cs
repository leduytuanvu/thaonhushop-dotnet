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
            // Add services to the container
            services.AddControllers();

            // ADD PROBLEM DETAILS FACTORY
            services.AddSingleton<ProblemDetailsFactory, ThaoNhuShopProblemDetailsFactory>();

            // ADD AUTOMAPPER
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // ADD DBCONTEXT WITH SINGLETON
            //services.AddDbContext<ThaoNhuShopDbContext>(
            //    options => options.UseSqlServer(
            //        "name=ConnectionStrings:ThaoNhuShop",
            //        b => b.MigrationsAssembly("ThaoNhuShop.Api")
            //    ), ServiceLifetime.Singleton
            //);

            services.AddEntityFrameworkNpgsql().AddDbContext<ThaoNhuShopDbContext>(options =>
                options.UseNpgsql(
                    "name=ConnectionStrings:ThaoNhuShop",
                    b => b.MigrationsAssembly("ThaoNhuShop.Api")
                ), ServiceLifetime.Singleton
            );

            return services;
        }
    }

}