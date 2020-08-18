
namespace TravelPlans.API.Common.Settings
{
    public class AzureAdSettings
    {
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
