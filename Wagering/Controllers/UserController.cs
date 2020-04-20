﻿using Microsoft.AspNetCore.Mvc;
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

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetUser(string name)
        {
            name = name.ToUpper();
            var user = await _context.Users.Include(x => x.Ratings).FirstOrDefaultAsync(x => x.NormalizedUserName == name);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("search/{query}")]
        public async Task<IActionResult> SearchUsers(string query)
        {
            query = query.ToUpper();
            var user = await _context.Users.Where(x => x.NormalizedUserName.Contains(query)).Take(ResultSize).ToListAsync();
            return Ok(user);
        }
    }
}