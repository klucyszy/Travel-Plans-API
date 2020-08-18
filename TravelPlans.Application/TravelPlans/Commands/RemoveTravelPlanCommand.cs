using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.TravelPlans.Exceptions;
using TravelPlans.Application.TravelPlans.Policies;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class RemoveTravelPlanCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CurrentUserId { get; set; }
        public bool IsAdmin { get; set; }

        public class RemoveTravelPlanCommandHandler : IRequestHandler<RemoveTravelPlanCommand>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;

            public RemoveTravelPlanCommandHandler(ITravelPlansRepository _travelPlansRepository)
            {
                this._travelPlansRepository = _travelPlansRepository;
            }

            public async Task<Unit> Handle(RemoveTravelPlanCommand request, CancellationToken cancellationToken)
            {
                TravelPlan travelPlan = await _travelPlansRepository.GetAsync(request.Id);
                if (travelPlan is null)
                {
                    throw new TravelPlanNotFoundException(request.Id);
                }

                TravelPlansPolicies.ValidateIsAdminOrAddingAccessingOwnTravelPlan(request.IsAdmin, request.CurrentUserId, travelPlan.UserId);

                await _travelPlansRepository.DeleteAsync(request.Id);

                return Unit.Value;
            }
        }
    }
}
