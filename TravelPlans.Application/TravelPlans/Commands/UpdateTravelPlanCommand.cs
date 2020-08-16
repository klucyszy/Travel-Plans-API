using TravelPlans.Application.TravelPlans.Dtos;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class UpdateTravelPlanCommand
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public TravelPlanDto TravelPlan { get; set; }
    }
}
