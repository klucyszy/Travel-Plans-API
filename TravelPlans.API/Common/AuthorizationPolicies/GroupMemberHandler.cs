using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlans.API.Common.AuthorizationPolicies
{
    public class GroupMemberHandler : AuthorizationHandler<GroupMemberRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GroupMemberRequirement requirement)
        {
            var groupClaim = context.User.Claims
                 .FirstOrDefault(claim => claim.Type == "groups" &&
                     claim.Value.Equals(requirement.Id, StringComparison.InvariantCultureIgnoreCase));

            if (groupClaim != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
