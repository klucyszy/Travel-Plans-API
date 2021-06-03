using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TravelPlans.Messaging.Events;

namespace TravelPlans.Application.Calendar.Events.External.Handlers
{
    public class TravelPlanAddedConsumer : IConsumer<TravelPlanAdded>
    {
        private readonly ILogger<TravelPlanAddedConsumer> _logger;

        public TravelPlanAddedConsumer(ILogger<TravelPlanAddedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TravelPlanAdded> context)
        {
            _logger.LogInformation($"[Calendar] TravelPlanAddedConsumer invoked for Travel Plan with ID: {context.Message.Id}");

            return Task.CompletedTask;
        }
    }
}
