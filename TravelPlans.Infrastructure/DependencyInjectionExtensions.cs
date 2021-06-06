
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelPlans.Infrastructure.Sql.Context;
using MassTransit;
using System;
using System.Linq;
using TravelPlans.Messaging.Events;
using Calendar = TravelPlans.Application.Calendar.Events.External.Handlers;
using Emails = TravelPlans.Application.Emails.Events.External.Handlers;
using TravelPlans.Messaging.Abstractions;
using MassTransit.Azure.ServiceBus.Core;

namespace TravelPlans.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        private static readonly string ServiceBusKey = "Endpoint=sb://mass-transit-demo-sbn.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=tWBBmG15y6YI8PTRTR5JRysK94oV6KszrMVV0ca6BeA=";

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

        public static IServiceCollection AddMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(opts =>
            {
                var solutionAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("TravelPlans"));
                foreach(var assembly in solutionAssemblies)
                {
                    opts.AddConsumers(assembly);
                }

                opts.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host(ServiceBusKey, hostCfg => hostCfg.TransportType = Microsoft.Azure.ServiceBus.TransportType.AmqpWebSockets);
                    
                    cfg.ConfigureSubscribersFor<TravelPlanAdded>(context,
                        typeof(Calendar.TravelPlanAddedConsumer),
                        typeof(Emails.TravelPlanAddedConsumer));

                });
            });

            services.AddMassTransitHostedService();

            return services;
        }

        #region Helpers

        private static IServiceBusBusFactoryConfigurator ConfigureSubscribersFor<TEvent>(this IServiceBusBusFactoryConfigurator @this,
            IBusRegistrationContext context, params Type[] subscribers) where TEvent : class, IEvent
        {
            @this.Message<TEvent>(m => m.SetEntityName(typeof(TEvent).FullName));

            foreach (var subscriberType in subscribers)
            {
                @this.SubscriptionEndpoint<TEvent>(ExtractSubsriptionName(subscriberType), endCfg =>
                {
                    endCfg.ConfigureConsumer(context, subscriberType);
                });
            }

            return @this;
        }

        private static string ExtractSubsriptionName(Type type)
        {
            string assemblyName = type.Assembly.GetName().Name;
            string consumerFullName = type.FullName;
            string subscriptionName = consumerFullName
                .Replace($"{assemblyName}.", string.Empty)
                .Replace("External.", string.Empty)
                .Replace("Handlers.", string.Empty);

            return subscriptionName.Length > 50
                ? subscriptionName.Substring(0, 50)
                : subscriptionName;
        }

        #endregion
    }
}
