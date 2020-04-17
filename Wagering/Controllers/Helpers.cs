using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    public static class Helpers
    {
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
