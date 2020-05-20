using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;

namespace Wagering
{
    public static class Extensions
    {
        public static bool IsUnique<T>(this IEnumerable<T> list)
        {
            var hs = new HashSet<T>();
            return list.All(hs.Add);
        }

        public static string? GetId(this ClaimsPrincipal User)
        {
            return User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public static string? GetName(this ClaimsPrincipal User)
        {
            return User.Claims.FirstOrDefault(x => x.Type == Constants.Claims.DisplayName)?.Value;
        }

        public static Claim NameClaim(this IList<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == Constants.Claims.DisplayName);
        }

        public static Claim VerifiedClaim(this IList<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == Constants.Claims.IsVerified);
        }

        public static Claim KeyClaim(this IList<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == Constants.Claims.PublicKey);
        }
    }
}