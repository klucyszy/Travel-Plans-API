using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace TravelPlans.API.Common.Extensions
{
    public static class ClaimsReaderExtension
    {
        public static string TryGetClaim(this IEnumerable<Claim> claims, string type)
        {
            return claims.Where(x => x.Type == type).SingleOrDefault()?.Value;
        }

        public static IEnumerable<string> TryGetClaimAsEnumerable(this IEnumerable<Claim> claims, string type)
        {
            return claims.Where(c => c != null && c.Type == type).Select(c => c.Value);
        }
    }
}
