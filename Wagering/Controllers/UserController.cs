using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private const int ResultSize = 5;
        private readonly ErrorMessages _errorMessages = new ErrorMessages { Name = "user" };

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetUser(string name)
        {
            name = name.ToUpper();
            var user = await _context.Profiles.Where(x => x.NormalizedDisplayName == name).Include(x => x.Ratings).FirstOrDefaultAsync();
            if (user == null)
            {
                ModelState.AddModelError("Not found", _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpGet("search/{query}")]
        public async Task<IActionResult> SearchUsers(string query)
        {
            query = query.ToUpper();
            var user = await _context.Profiles.Where(x => x.NormalizedDisplayName.Contains(query)).Take(ResultSize).ToListAsync();
            return Ok(user);
        }
    }
}
