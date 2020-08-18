using System;
using System.Collections.Generic;

namespace TravelPlans.API.Model.TravelPlans
{
    public class AddTravelPlanDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<string> Locations { get; set; }
    }
}
