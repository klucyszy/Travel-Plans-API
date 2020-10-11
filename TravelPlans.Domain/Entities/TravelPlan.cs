using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelPlans.Domain.Entities
{
    public class TravelPlan : AggregateRoot
    {
        private ISet<string> _locations;
        private ISet<TravelPlan> _travelPlans;

        public IEnumerable<TravelPlan> TravelPlans
        {
            get => _travelPlans;
            set => _travelPlans = new HashSet<TravelPlan>(value);
        }

        public IEnumerable<string> Locations
        {
            get => _locations;
            set => _locations = new HashSet<string>(value);
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public TravelPlan(int id, string userId, string name, DateTime? startDate, DateTime? endDate,
            IEnumerable<string> locations, IEnumerable<TravelPlan> travelPlans = null)
        {
            Id = id;
            UserId = userId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Locations = locations ?? Enumerable.Empty<string>();
            TravelPlans = travelPlans ?? Enumerable.Empty<TravelPlan>();
        }

        public TravelPlan() : this(0, null, null, null, null, Enumerable.Empty<string>()) { }

        public void AddTravelPlan()
        {

        }

    }
}
