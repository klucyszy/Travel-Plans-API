using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TravelPlans.Messaging.Abstractions;
using TravelPlans.Messaging.Events;

namespace TravelPlans.Application.Emails.Events.External.Handlers
{
    public class TravelPlanAddedConsumer : IEventConsumer<TravelPlanAdded>
    {
        private readonly ILogger<TravelPlanAddedConsumer> _logger;

        public TravelPlanAddedConsumer(ILogger<TravelPlanAddedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TravelPlanAdded> context)
        {
            _logger.LogInformation($"[Emails] TravelPlanAddedConsumer invoked for Travel Plan with ID: {context.Message.Id}");

            return Task.CompletedTask;
        }
    }
}
