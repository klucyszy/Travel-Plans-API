using System;

namespace TravelPlans.Application.TravelPlans.Exceptions
{

    [Serializable]
    public class InsufficientPrivilidgesException : Exception
    {
        public InsufficientPrivilidgesException() : base("User if not privilidged to perform that action") { }
    }
}
