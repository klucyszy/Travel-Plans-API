using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TravelPlans.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
