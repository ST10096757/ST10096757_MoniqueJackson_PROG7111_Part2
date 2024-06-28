using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AngryEnergy_Test.Models;
using AngryEnergy_Test.Data;

namespace AngryEnergy_Test.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public ActionResult SetPassword(string userId, string email)
        {
            var model = new UserModel { Id = userId, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SetPassword(string email, string password, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    // Handle case where user is not found
                    return NotFound();
                }

                // Attempt to reset password
                var result = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), password);
                if (result.Succeeded)
                {
                    // Password reset successful
                    return RedirectToAction("Index", "Home"); // Redirect to success page
                }
                else
                {
                    // Add errors to TempData to display in the view
                    foreach (var error in result.Errors)
                    {
                        TempData["ErrorMessage"] += error.Description + " ";
                    }
                }
            }


            // If ModelState is not valid, return the view with errors
            return View();

        }
    }
}
