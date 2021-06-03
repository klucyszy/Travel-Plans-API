using System.Threading.Tasks;

namespace TravelPlans.Infrastructure.Events
{
    public interface IEventBroker
    {
        Task PublishAsync<TEvent>() where TEvent : IEvent;
    }
}
