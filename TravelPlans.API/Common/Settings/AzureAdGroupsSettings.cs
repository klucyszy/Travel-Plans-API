using System.Collections.Generic;

namespace TravelPlans.API.Common.Settings
{
    public class AzureAdGroupsSettings
    {
        public IEnumerable<AzureAdGroup> AzureAdSecurityGroups { get; set; }
    }
}
