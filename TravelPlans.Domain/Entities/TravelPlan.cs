using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelPlans.Domain.Entities
{
    public class TravelPlan
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Locations { get; set; }

        public TravelPlan(int id, string userId, string name, DateTime? startDate, DateTime? endDate, IEnumerable<string> locations)
        {
            Id = id;
            UserId = userId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SetLocations(locations);
        }

        public TravelPlan() : this(0, null, null, null, null, Enumerable.Empty<string>()) { }

        public IEnumerable<string> GetLocations() 
            => JsonConvert.DeserializeObject<IEnumerable<string>>(Locations ?? "[]");
        public void SetLocations(IEnumerable<string> locations) 
            => Locations = JsonConvert.SerializeObject(locations ?? Enumerable.Empty<string>());
    }
}
