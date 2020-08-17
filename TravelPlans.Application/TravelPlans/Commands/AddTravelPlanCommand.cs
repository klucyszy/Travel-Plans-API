using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.Common.Commands;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class AddTravelPlanCommand : ICommand
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<string> Locations { get; set; }

        private class AddTravelPlanCommandHandler : IRequestHandler<AddTravelPlanCommand>
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
