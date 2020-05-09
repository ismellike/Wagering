﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public GroupController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }
            List<string> hostGroups = new List<string>();
            List<string> clientGroups = new List<string>();
            hostGroups.AddRange(await _context.WagerHostBids.Include(x => x.Wager).Where(x => x.UserId == user.Id).Where(x => x.Wager.Status <= 1).Select(x => x.Wager.GroupName).ToListAsync());
            return Ok(new { hostGroups, clientGroups });
        }
    }
}