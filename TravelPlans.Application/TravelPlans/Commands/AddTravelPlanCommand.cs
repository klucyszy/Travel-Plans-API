using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class AddTravelPlanCommand : IRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<string> Locations { get; set; }

        public class AddTravelPlanCommandHandler : IRequestHandler<AddTravelPlanCommand>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;

            public AddTravelPlanCommandHandler(ITravelPlansRepository travelPlansRepository)
            {
                _travelPlansRepository = travelPlansRepository;
            }

            public async Task<Unit> Handle(AddTravelPlanCommand request, CancellationToken cancellationToken)
            {
                var travelPlan = new TravelPlan
                {
                    UserId = request.UserId,
                    Name = request.Name,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                };
                travelPlan.SetLocations(request.Locations);

                await _travelPlansRepository.AddAsync(travelPlan);

                return Unit.Value;
            }
        }
    }
}
