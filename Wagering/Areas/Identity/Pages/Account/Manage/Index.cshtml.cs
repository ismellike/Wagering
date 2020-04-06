using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Public Key")]
            public string PublicKey { get; set; }
        }

        private void Load(Profile user)
        {
            Username = user.DisplayName;

            Input = new InputModel
            {
                PublicKey = user.PublicKey
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _context.GetProfileAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            Load(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var profile = await _context.GetProfileAsync(User.Identity.Name);
            ApplicationUser user = _context.Users.Find(profile.UserId);
            if (profile == null || user == null)
            {
                return NotFound($"Unable to load user.");
            }

            if (!ModelState.IsValid)
            {
                Load(profile);
                return Page();
            }

            var key = profile.PublicKey;
            if (Input.PublicKey != key)
            {
                profile.PublicKey = Input.PublicKey;
                _context.Profiles.Update(profile);
                await _context.SaveChangesAsync();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
