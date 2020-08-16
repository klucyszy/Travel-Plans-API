﻿
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelPlans.Infrastructure.Sql.Context;

namespace TravelPlans.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<TravelPlansContext>(opts => opts.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOpts => sqlOpts.MigrationsAssembly(typeof(TravelPlansContext).Assembly.FullName)));

            services.AddTransient<ITravelPlansContext>(provider => provider.GetService<TravelPlansContext>());
            services.AddTransient<ITravelPlansRepository, TravelPlansRepository>();

            return services;
        }
    }
}