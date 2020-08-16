using MediatR;

namespace TravelPlans.Application.Common.Commands
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {
        
    }
}
