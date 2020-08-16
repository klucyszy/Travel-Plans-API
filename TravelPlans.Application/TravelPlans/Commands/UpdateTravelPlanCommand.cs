using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.Common.Commands;
using TravelPlans.Application.TravelPlans.Dtos;
using TravelPlans.Application.TravelPlans.Exceptions;
using TravelPlans.Application.TravelPlans.Extensions;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class UpdateTravelPlanCommand : ICommand
    {
        public TravelPlanDto TravelPlan { get; set; }

        private class UpdateTravelPlanCommandHandler : IRequestHandler<UpdateTravelPlanCommand>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;

            public UpdateTravelPlanCommandHandler(ITravelPlansRepository travelPlansRepository)
            {
                _travelPlansRepository = travelPlansRepository;
            }

            public async Task<Unit> Handle(UpdateTravelPlanCommand request, CancellationToken cancellationToken)
            {
                if (!await _travelPlansRepository.ExistsAsync(request.TravelPlan.Id))
                {
                    throw new TravelPlanNotFoundException("Travel plan not found");
                }

                var travelPlan = request.TravelPlan.AsEntity(request.TravelPlan.Id);

                await _travelPlansRepository.UpdateAsync(travelPlan);

                return Unit.Value;
            }
        }
    }
}
