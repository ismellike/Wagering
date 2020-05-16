using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData]
        public string? StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        //Maybe allow for name changes later ?
        public class InputModel
        {
            //[RegularExpression(Constants.NameRegex)]
            //[StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
            public string? DisplayName { get; set; }
            public string? Email { get; set; }
            [DataType(DataType.PhoneNumber)]
            public string? PhoneNumber { get; set; }
        }

        private async Task Load(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            Input = new InputModel
            {
                DisplayName = claims.FirstOrDefault(x => x.Type == "display_name")?.Value,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
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

            var number = user.PhoneNumber;
            if (Input.PhoneNumber != number)
            {
                var result = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
