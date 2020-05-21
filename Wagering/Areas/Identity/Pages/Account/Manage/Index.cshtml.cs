using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
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

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        //Maybe allow for name changes later ?
        public class InputModel
        {
            public string? Email { get; set; }
            //[RegularExpression(Constants.NameRegex)]
            //[StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
            public string? DisplayName { get; set; }
        }

        private async Task Load(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            Input = new InputModel
            {
                Email = user.Email,
                DisplayName = claims.NameClaim()?.Value
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
    }
}
