using Microsoft.EntityFrameworkCore;
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
