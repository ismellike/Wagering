using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public class AccountModel
        {
            [Required]
            [StringLength(12, MinimumLength = 4)]
            public string Username { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 6)]
            public string Password { get; set; }
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody]AccountModel account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = account.Username,
                Email = account.Email,
                Profile = new Profile
                {
                    DisplayName = account.Username,
                    IsVerified = false
                }
            };

            var result = await _userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.Code, error.Description);
                return BadRequest(ModelState);
            }
            return Ok();
        }

        public class LoginModel
        {
            [Required]
            [StringLength(12, MinimumLength = 4)]
            public string Username { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 6)]
            public string Password { get; set; }
        }

        [HttpPost("login")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, true, false);

            if (!result.Succeeded)
            {
                if (result.RequiresTwoFactor)
                {

                }
                if (result.IsLockedOut)
                {

                }
                ModelState.AddModelError("Invalid", "Invalid login attempt");
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}