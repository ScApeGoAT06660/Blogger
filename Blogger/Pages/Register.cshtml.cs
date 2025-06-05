using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Blogger.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public Register Register { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new IdentityUser
            {
                UserName = Register.Name,
                Email = Register.Email
            };

            var identityResult = await _userManager.CreateAsync(user, Register.Password);

            if (identityResult.Succeeded)
            {
                var addRoleResult = await _userManager.AddToRoleAsync(user, "User");

                if (addRoleResult.Succeeded)
                {
                    TempData["SuccessMessage"] = "Account created successfully!";

                    return RedirectToPage("/Index");
                }              
            }

            TempData["ErrorMessage"] = "Something went wrong while creating the account.";

            return Page();
        }
    }
}
