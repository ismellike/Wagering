using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Wagering.Handlers;
using Wagering.Models;

namespace Wagering.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [TempData]
        public string? StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        //Maybe allow for name changes later ?
        public class InputModel
        {
            public string? Email { get; set; }
            //[RegularExpression(Constants.NameRegex)]
            //[StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
            public string? DisplayName { get; set; }
            [CustomValidation(typeof(StellarHandler), "IsPublicKeyValid", ErrorMessage = "{0} is not a valid stellar public key.")]
            public string? PublicKey { get; set; }
        }

        private async Task Load(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            Input = new InputModel
            {
                Email = user.Email,
                DisplayName = claims.NameClaim()?.Value,
                PublicKey = claims.KeyClaim()?.Value
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            await Load(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            if (!ModelState.IsValid)
            {
                await Load(user);
                return Page();
            }
            var claims = await _userManager.GetClaimsAsync(user);
            var profile = await _context.Profiles.FindAsync(user.Id);

            var publicKey = profile.PublicKey;
            if (Input.PublicKey != publicKey)
            {
                profile.PublicKey = Input.PublicKey;
                Claim keyClaim = claims.KeyClaim();
                Claim newClaim = new Claim(Constants.Claims.PublicKey, Input.PublicKey);

                if (keyClaim == null)
                    await _userManager.AddClaimAsync(user, newClaim);
                else
                    await _userManager.ReplaceClaimAsync(user, keyClaim, newClaim);
                _context.Profiles.Update(profile);
                _context.SaveChanges();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
