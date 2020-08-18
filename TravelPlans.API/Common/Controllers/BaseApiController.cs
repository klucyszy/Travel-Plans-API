using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TravelPlans.API.Common.Models;
using TravelPlans.API.Common.Settings;

namespace TravelPlans.API.Common.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private ApplicationUser _currentUser;
        protected ApplicationUser CurrentUser => _currentUser ??= new ApplicationUser(
            HttpContext.User.Claims, HttpContext.RequestServices.GetService<IOptions<AzureAdSettings>>()?.Value);
    }
}
