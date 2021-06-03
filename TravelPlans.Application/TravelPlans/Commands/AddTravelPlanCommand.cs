using Domain.Repositories;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.TravelPlans.Policies;
using TravelPlans.Domain.Entities;
using TravelPlans.Messaging.Events;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class AddTravelPlanCommand : IRequest
    {
        public string UserId { get; set; }
        public string CurrentUserId { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<string> Locations { get; set; }

        public class AddTravelPlanCommandHandler : IRequestHandler<AddTravelPlanCommand>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;
            private readonly IPublishEndpoint _publishEndpoint;

            public AddTravelPlanCommandHandler(
                ITravelPlansRepository travelPlansRepository,
                IPublishEndpoint publishEndpoint)
            {
                _travelPlansRepository = travelPlansRepository;
                _publishEndpoint = publishEndpoint;
            }

            public async Task<Unit> Handle(AddTravelPlanCommand request, CancellationToken cancellationToken)
            {
                TravelPlansPolicies.ValidateIsAdminOrAddingAccessingOwnTravelPlan(request.IsAdmin, request.CurrentUserId, request.UserId);

                var travelPlan = new TravelPlan
                {
                    UserId = request.UserId,
                    Name = request.Name,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                };
                travelPlan.SetLocations(request.Locations);

                await _travelPlansRepository.AddAsync(travelPlan);

                await _publishEndpoint.Publish(new TravelPlanAdded(travelPlan.Id));

                return Unit.Value;
            }
        }
    }
}
