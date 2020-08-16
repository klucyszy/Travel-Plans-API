using Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.Common.Queries;
using TravelPlans.Application.TravelPlans.Dtos;
using TravelPlans.Application.TravelPlans.Extensions;

namespace TravelPlans.Application.TravelPlans.Queries
{
    public class GetTravelPlansQuery : IQuery<IEnumerable<TravelPlanDto>>
    {
        public string UserId { get; set; }

        public GetTravelPlansQuery(string userId)
        {
            UserId = userId;
        }

        private class GetTravelPlansQueryHandler : IRequestHandler<GetTravelPlansQuery, IEnumerable<TravelPlanDto>>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;

            public GetTravelPlansQueryHandler(ITravelPlansRepository travelPlansRepository)
            {
                _travelPlansRepository = travelPlansRepository;
            }

            public async Task<IEnumerable<TravelPlanDto>> Handle(GetTravelPlansQuery request, CancellationToken cancellationToken)
            {
                var travelPlans = await _travelPlansRepository.GetAllAsync(request.UserId);

                return travelPlans.AsDtoEnumerable();
            }
        }
    }
}
