using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Application.TravelPlans.Dtos;
using TravelPlans.Application.TravelPlans.Extensions;

namespace TravelPlans.Application.TravelPlans.Queries
{
    public class GetTravelPlansQuery : IRequest<TravelPlansPageDto>
    {
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }

        public GetTravelPlansQuery(string userId, bool isAdmin)
        {
            UserId = userId;
            IsAdmin = isAdmin;
        }

        private class GetTravelPlansQueryHandler : IRequestHandler<GetTravelPlansQuery, TravelPlansPageDto>
        {
            private readonly ITravelPlansRepository _travelPlansRepository;

            public GetTravelPlansQueryHandler(ITravelPlansRepository travelPlansRepository)
            {
                _travelPlansRepository = travelPlansRepository;
            }

            public async Task<TravelPlansPageDto> Handle(GetTravelPlansQuery request, CancellationToken cancellationToken)
            {
                var travelPlans = await _travelPlansRepository.GetAllAsync(request.UserId);

                return new TravelPlansPageDto(travelPlans.AsDtoEnumerable(), request.IsAdmin);
            }
        }
    }
}
