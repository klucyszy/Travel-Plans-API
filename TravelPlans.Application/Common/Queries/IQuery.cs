using MediatR;

namespace TravelPlans.Application.Common.Queries
{
    public interface IQuery : IRequest
    {

    }

    public interface IQuery<TResponse> : IRequest<TResponse>
    {

    }
}
