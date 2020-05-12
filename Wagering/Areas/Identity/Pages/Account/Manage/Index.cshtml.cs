using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Wagering.Models;
using System;

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

        public string? Username { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Display(Name = "Phone")]
            public string? PhoneNumber { get; set; }
        }

        private void Load(ApplicationUser user)
        {
            Username = user.UserName;

            Input = new InputModel
            {
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

            Load(user);
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
                Load(user);
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
