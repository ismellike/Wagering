using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering
{
    public static class Helpers
    {
        public static string ToURL(this string name)
        {
            return Regex.Replace(name, "[^a-zA-Z0-9_.:]+", string.Empty).ToLower();
        }

        public static string ToString(this List<WagerHostBid> hosts, int cutoff)
        {
            if (hosts.Count > cutoff)
                return $"{string.Join(", ", hosts.GetRange(0, cutoff - 1))}, +{hosts.Count - cutoff + 1} more...";
            return string.Join(", ", hosts);
        }

        public static string ToString(this decimal? value, string nullResult)
        {
            if (value.HasValue)
                return value.Value.ToString();
            return nullResult;
        }

        public static async Task<Profile> GetProfileAsync(this ApplicationDbContext context, ClaimsPrincipal User)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await context.Profiles.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public static async Task<Profile> GetProfileAsync(this ApplicationDbContext context, string name)
        {
            return await context.Profiles.FirstOrDefaultAsync(x => x.DisplayName == name);
        }
    }
}
