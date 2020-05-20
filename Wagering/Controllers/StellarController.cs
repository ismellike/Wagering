using Microsoft.AspNetCore.Mvc;
using stellar_dotnet_sdk;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StellarController : ControllerBase
    {
        private readonly Server _server;
        public StellarController(Server server)
        {
            _server = server;
        }
        [HttpGet]
        public IActionResult RequestChallenge([FromQuery] string account)
        {
            //need server keys here
            WebAuthentication.BuildChallengeTransaction(null, account, "Wagering.gg");
            return Ok();
        }
    }
}