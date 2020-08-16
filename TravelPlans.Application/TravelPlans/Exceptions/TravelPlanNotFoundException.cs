using System;

namespace TravelPlans.Application.TravelPlans.Exceptions
{

    [Serializable]
    public class TravelPlanNotFoundException : Exception
    {
        public TravelPlanNotFoundException() { }
        public TravelPlanNotFoundException(string message) : base(message) { }
        public TravelPlanNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TravelPlanNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
