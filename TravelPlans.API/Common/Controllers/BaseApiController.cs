using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using TravelPlans.API.Common.Models;
using TravelPlans.API.Common.Settings;

namespace TravelPlans.API.Common.Controllers
{
    [Authorize(Policy = "Users")]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private ApplicationUser _currentUser;
        protected ApplicationUser CurrentUser => _currentUser ??= CreateApplicationUser();

        private ApplicationUser CreateApplicationUser()
        {
            var azureAdGroupSettings = HttpContext.RequestServices.GetService<IOptions<AzureAdGroupsSettings>>();

            return new ApplicationUser(
                HttpContext.User.Claims, 
                azureAdGroupSettings?.Value?.AzureAdSecurityGroups?.FirstOrDefault(g => g.Name == "Admins")?.Id);
        }
    }
}
