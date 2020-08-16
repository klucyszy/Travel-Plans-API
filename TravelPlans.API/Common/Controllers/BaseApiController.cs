using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TravelPlans.API.Common.Models;

namespace TravelPlans.API.Common.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private ApplicationUser _currentUser;
        protected ApplicationUser CurrentUser => _currentUser ??= new ApplicationUser(HttpContext.User.Claims);
    }
}
