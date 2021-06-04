using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.TravelPlans.Exceptions;
using TravelPlans.Application.TravelPlans.Policies;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class UpdateTravelPlanCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CurrentUserId { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<string> Locations { get; set; }

        internal class UpdateTravelPlanCommandHandler : IRequestHandler<UpdateTravelPlanCommand>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;

            public UpdateTravelPlanCommandHandler(ITravelPlansRepository travelPlansRepository)
            {
                _travelPlansRepository = travelPlansRepository;
            }

            public async Task<Unit> Handle(UpdateTravelPlanCommand request, CancellationToken cancellationToken)
            {
                TravelPlansPolicies.ValidateIsAdminOrAddingAccessingOwnTravelPlan(request.IsAdmin, request.CurrentUserId, request.UserId);

                if (!await _travelPlansRepository.ExistsAsync(request.Id))
                {
                    throw new TravelPlanNotFoundException(request.Id);
                }

                TravelPlan travelPlan = new TravelPlan(
                    request.Id,
                    request.UserId,
                    request.Name,
                    request.StartDate,
                    request.EndDate,
                    request.Locations);

                await _travelPlansRepository.UpdateAsync(travelPlan);

                return Unit.Value;
            }
        }
    }
}
