﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wagering.Data;
using Wagering.Models;

namespace Wagering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Wagers/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Wager>> GetProfile(string name)
        {
            var profile = await _context.Profiles.Include(x => x.Ratings).Include(x => x.PublicKey).FirstOrDefaultAsync(x => x.DisplayName == name);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }
    }
}
