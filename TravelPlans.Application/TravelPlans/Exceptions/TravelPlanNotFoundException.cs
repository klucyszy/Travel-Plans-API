using System;

namespace TravelPlans.Application.TravelPlans.Exceptions
{

    [Serializable]
    public class TravelPlanNotFoundException : Exception
    {
        public int Id { get; set; }
        public TravelPlanNotFoundException(int id) : base($"Travel plan with {id} not found") => Id = id;
    }
}
