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

        public class Account
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
        public async Task<IActionResult> CreateAccount([FromBody]Account account)
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

            await _signInManager.SignInAsync(user, false);
            return Ok();
        }
    }
}