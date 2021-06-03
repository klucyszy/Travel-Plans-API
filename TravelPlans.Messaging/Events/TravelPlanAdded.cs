namespace TravelPlans.Messaging.Events
{
    public class TravelPlanAdded
    {
        public TravelPlanAdded(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
