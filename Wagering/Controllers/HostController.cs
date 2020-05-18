using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wagering.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ErrorMessages _errorMessages = new ErrorMessages();

        public HostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("wagers")]
        [Authorize]
        public async Task<IActionResult> ControlWagers()
        {
            string? userId = User.GetId();
            List<Wager> results = await _context.WagerHostBids.AsNoTracking().Where(x => x.ProfileId == userId).Include(x => x.Wager).ThenInclude(x => x.Hosts).ThenInclude(x => x.Profile).Select(x => x.Wager).ToListAsync();
            return Ok(results);
        }

        [HttpGet("wagers/{id}")]
        [Authorize]
        public async Task<IActionResult> GetControlWager(int id)
        {
            string? userId = User.GetId();

            Wager wager = await _context.Wagers.AsNoTracking().Where(x => x.Id == id).Include(x => x.Hosts).ThenInclude(x => x.Profile).Include(x => x.Challenges).ThenInclude(x => x.Challengers).ThenInclude(x => x.Profile).FirstOrDefaultAsync();

            if (wager == null)
            {
                _errorMessages.Name = "Wager";
                ModelState.AddModelError(string.Empty, _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (!wager.Hosts.Any(x => x.ProfileId == userId))
            {
                ModelState.AddModelError(string.Empty, "You are not a host of this wager.");
                return BadRequest(ModelState);
            }
            return Ok(wager);
        }
    }
}