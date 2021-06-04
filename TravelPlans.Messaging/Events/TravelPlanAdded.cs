using TravelPlans.Messaging.Abstractions;

namespace TravelPlans.Messaging.Events
{
    public class TravelPlanAdded : IEvent
    {
        public TravelPlanAdded(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
