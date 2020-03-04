﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;
using Wagering.Models;
using Stellar = stellar_dotnet_sdk;
using System.Security.Claims;

namespace Wagering.Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StellarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StellarController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a test account for the stellar network
        /// </summary>
        /// <returns>key pair value</returns>
        [HttpGet("/create")]
        public async Task<IActionResult> CreateAccount()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (profile == null)
                return Unauthorized();

            //create account public key and secret seed
            Stellar.KeyPair pair = Stellar.KeyPair.Random();
            profile.PublicKey = pair.AccountId;
            string url = $"https://friendbot.stellar.org/?addr={pair.AccountId}";
            //create account on stellar test net
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return Conflict();

            return Ok(pair);
        }
    }
}