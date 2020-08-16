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
        public IEnumerable<string> Locations { get; set; }
        public string LocationsString => JsonConvert.SerializeObject(Locations ?? Enumerable.Empty<string>());
    }
}
