using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _userManager;

        [BindProperty]
        public Register Login { get; set; }

        public LoginModel(SignInManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost()
        {
            var signInResult = await _userManager.PasswordSignInAsync(Login.Name, Login.Password, false, false);

            if (signInResult.Succeeded)
            {
                return RedirectToPage("/Index");
            }

            TempData["ErrorMessage"] = "Something went wrong while logging in.";

            return Page();
        }
    }
}
