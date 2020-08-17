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

        public IEnumerable<string> GetLocations()
        {
            return JsonConvert.DeserializeObject<IEnumerable<string>>(Locations ?? "[]");
        }

        public void SetLocations(IEnumerable<string> locations)
        {
            Locations = JsonConvert.SerializeObject(locations ?? Enumerable.Empty<string>());
        }


    }
}
