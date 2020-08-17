using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.Common.Commands;
using TravelPlans.Application.TravelPlans.Exceptions;

namespace TravelPlans.Application.TravelPlans.Commands
{
    public class RemoveTravelPlanCommand : ICommand
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public RemoveTravelPlanCommand(int id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        internal class RemoveTravelPlanCommandHandler : IRequestHandler<RemoveTravelPlanCommand>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;

            public RemoveTravelPlanCommandHandler(ITravelPlansRepository _travelPlansRepository)
            {
                this._travelPlansRepository = _travelPlansRepository;
            }

            public async Task<Unit> Handle(RemoveTravelPlanCommand request, CancellationToken cancellationToken)
            {
                if (!await _travelPlansRepository.ExistsAsync(request.Id))
                {
                    throw new TravelPlanNotFoundException(request.Id);
                }

                await _travelPlansRepository.DeleteAsync(request.Id);

                return Unit.Value;
            }
        }
    }
}
