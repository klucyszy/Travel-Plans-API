using System;

namespace TravelPlans.Application.TravelPlans.Exceptions
{
    [Serializable]
    public class TravelPlanNotFoundException : NotFoundApplicationException
    {
        public TravelPlanNotFoundException(int id) : base($"Travel plan with ID: {id} was not found.", id) { }
    }
}
