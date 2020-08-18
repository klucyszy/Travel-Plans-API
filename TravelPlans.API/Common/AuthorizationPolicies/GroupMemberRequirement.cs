using Microsoft.AspNetCore.Authorization;

namespace TravelPlans.API.Common.AuthorizationPolicies
{
    public class GroupMemberRequirement : IAuthorizationRequirement
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public GroupMemberRequirement(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public GroupMemberRequirement() : this(null, null) { }
    }
}
