﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TravelPlans.API.Common.Extensions;
using TravelPlans.API.Common.Settings;

namespace TravelPlans.API.Common.Models
{
    public class ApplicationUser
    {
        private string _adminGroupId = string.Empty;

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public IEnumerable<string> Groups { get; set; }
        public bool IsAdmin { get; set; }

        public ApplicationUser(IEnumerable<Claim> claims, string adminGroupId)
        {
            if (claims is null)
            {
                return;
            }

            _adminGroupId = adminGroupId;

            Id = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            FirstName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            LastName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname");
            DisplayName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            Email = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            Groups = claims.TryGetClaimAsEnumerable("groups");
            IsAdmin = claims.TryGetClaimAsEnumerable("groups").Any(g => g == _adminGroupId);
        }
    }
}

