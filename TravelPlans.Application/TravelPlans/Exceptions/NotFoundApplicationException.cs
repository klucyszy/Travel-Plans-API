using System;

namespace TravelPlans.Application.TravelPlans.Exceptions
{

    [Serializable]
    public class NotFoundApplicationException : Exception
    {
        public int Id { get; set; }
        public NotFoundApplicationException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
