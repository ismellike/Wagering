﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nethereum.JsonRpc.Client;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PanelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PanelController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Wagers
        [HttpGet("client/wagers")]
        public async Task<IActionResult> ClientChallenges()
        {
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();

            var requests = await _context.Challenges.Include(x => x.Challengers).Include(x => x.Wager).Where(x => x.Challengers.Any(x => x.UserDisplayName == profile.DisplayName)).ToListAsync();
            return Ok(requests);
        }

        [HttpGet("host/wagers")]
        public async Task<IActionResult> HostWagers()
        {
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();

            var requests = await _context.Wagers.Include(x => x.Challenges).ThenInclude(x => x.Challengers).Where(x => x.Hosts.Any(x => x.UserDisplayName == profile.DisplayName)).ToListAsync();
            return Ok(requests);
        }

        [HttpPost("host/wagers/edit")]
        public async Task<IActionResult> EditWager(Wager newWager)
        {
            //authorization
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();
            var wager = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync(x => x.Id == newWager.Id);
            if (wager == null)
                return BadRequest("Wager was not found.");
            if (!wager.Hosts.Any(x => x.UserDisplayName == profile.DisplayName))
                return Unauthorized();

            //reset all host and client approved to false
            foreach (var host in wager.Hosts)
                host.Approved = false;
            foreach (var challenge in wager.Challenges)
                foreach (var client in challenge.Challengers)
                    client.Approved = false;
            //set new wager
            //need to set percentage ratings & other users
            wager.Description = newWager.Description;
            wager.MinimumWager = newWager.MinimumWager;
            wager.MaximumWager = newWager.MaximumWager;
            wager.IsPrivate = newWager.IsPrivate;

            //save wager
            _context.Wagers.Update(wager);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("host/request")]
        public async Task<IActionResult> SendRequest(int wagerId, decimal amount)
        {
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();

            //check if wager belongs to user
            var wager = await _context.Wagers.FindAsync(wagerId);
            if (wager == null)
                return BadRequest("Wager was not found.");
            if (!wager.Hosts.Any(x => x.UserDisplayName == profile.DisplayName))
                return Unauthorized($"{profile.DisplayName} cannot request, because they are a host.");
            //send request to user
            //check for balance and hold
            wager.Challenges.Add(new WagerChallenge
            {
                Challengers = new WagerChallengeBid[]
                {
                    new WagerChallengeBid{
                    UserDisplayName = profile.DisplayName,
                    Approved = false,
                    Percentage = 100
                    }
                },
                Date = DateTime.Now,
                Amount = amount,
            });
            return Ok();
        }
        #endregion

        private async Task<Profile> GetProfileAsync()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _context.Profiles.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}