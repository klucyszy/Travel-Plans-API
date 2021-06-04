using MassTransit;

namespace TravelPlans.Messaging.Abstractions
{
    public interface IEventConsumer<in TMessage> : IConsumer<TMessage> where TMessage: class, IEvent
    {
    }
}
