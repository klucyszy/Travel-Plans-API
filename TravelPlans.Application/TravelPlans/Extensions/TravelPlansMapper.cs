using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelPlans.Application.TravelPlans.Dtos;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Application.TravelPlans.Extensions
{
    public static class TravelPlansMapper
    {
        public static TravelPlanDto AsDto(this TravelPlan travelPlan)
        {
            return new TravelPlanDto
            {
                Id = travelPlan.Id,
                Name = travelPlan.Name,
                StartDate = travelPlan.StartDate.HasValue ? travelPlan.StartDate.Value.ToString("yyyy-MM-dd") : null,
                EndDate = travelPlan.EndDate.HasValue ? travelPlan.EndDate.Value.ToString("yyyy-MM-dd") : null,
                Locations = JsonConvert.DeserializeObject<IEnumerable<string>>(travelPlan.LocationsString)
            };
        }
        
        public static IEnumerable<TravelPlanDto> AsDtoEnumerable(this IEnumerable<TravelPlan> travelPlans)
        {
            return travelPlans.Select(tr => tr.AsDto());
        }

        public static TravelPlan AsEntity(this TravelPlanDto travelPlanDto, int id)
        {
            return new TravelPlan
            {
                Id = id,
                UserId = travelPlanDto.UserId,
                Name = travelPlanDto.Name,
                StartDate = DateTime.Parse(travelPlanDto.StartDate),
                EndDate = DateTime.Parse(travelPlanDto.EndDate),
                Locations = travelPlanDto.Locations
            };
        }
    }
}
