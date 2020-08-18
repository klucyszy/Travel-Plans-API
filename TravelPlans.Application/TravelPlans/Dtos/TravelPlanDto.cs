using System.Collections.Generic;

namespace TravelPlans.Application.TravelPlans.Dtos
{
    public class TravelPlanDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IEnumerable<string> Locations { get; set; }
    }
}
