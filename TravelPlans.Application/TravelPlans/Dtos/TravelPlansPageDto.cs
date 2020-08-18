using System.Collections.Generic;
using System.Linq;

namespace TravelPlans.Application.TravelPlans.Dtos
{
    public class TravelPlansPageDto
    {
        public TravelPlansPageDto(IEnumerable<TravelPlanDto> travelPlans, bool isAdmin)
        {
            TravelPlans = travelPlans ?? Enumerable.Empty<TravelPlanDto>();
            IsAdmin = isAdmin;
        }

        public bool IsAdmin { get; set; }
        public IEnumerable<TravelPlanDto> TravelPlans { get; set; }
    }
}
