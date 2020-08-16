using System.Collections.Generic;
using System.Security.Claims;
using TravelPlans.API.Common.Extensions;

namespace TravelPlans.API.Common.Models
{
    public class ApplicationUser
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public bool IsAdmin { get; set; }

        public ApplicationUser(IEnumerable<Claim> claims)
        {
            if (claims is null)
            {
                return;
            }

            Id = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            FirstName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            LastName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname");
            DisplayName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            Email = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            IsAdmin = false; //TODO: Read from claims
        }
    }
}

