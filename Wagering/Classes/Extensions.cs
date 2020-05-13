using System.Collections.Generic;
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
            return User.Claims.FirstOrDefault(x => x.Type == "display_name")?.Value;
        }
    }
}