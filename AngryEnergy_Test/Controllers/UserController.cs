using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AngryEnergy_Test.Models;
using System.Diagnostics;


namespace AngryEnergy_Test.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(string email, string password)
		{
			if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
			{
				var user = new IdentityUser { UserName = email, Email = email };
				var result = await _userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		//[HttpPost]
		//public async Task<IActionResult> Login(string email, string password)
		//{
  //          if (ModelState.IsValid)
  //          {
  //              var user = await _userManager.FindByEmailAsync(email);
  //              if (user != null)
  //              {
  //                  // Check if user needs to set a new password (first-time login)
  //                  if (await NeedsPasswordReset(user))
  //                  {
  //                      // Redirect to SetPassword view with user information pre-filled
  //                      return RedirectToAction("SetPassword", new { userId = user.Id });
  //                  }
  //                  else
  //                  {
  //                      // Standard login process if not first-time login
  //                      var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
  //                      if (result.Succeeded)
  //                      {
  //                          // User successfully logged in, redirect to appropriate page
  //                          return RedirectToAction("Index", "Home");  // Replace with your desired action
  //                      }
  //                      else
  //                      {
  //                          ModelState.AddModelError(string.Empty, "Invalid login attempt.");
  //                      }
  //                  }
  //              }
  //              else
  //              {
  //                  ModelState.AddModelError(string.Empty, "Invalid username or password.");
  //              }
  //          }

  //          // Return to Login view with validation errors (if any)
  //          return View();
  //      }

        private async Task<bool> NeedsPasswordReset(IdentityUser user)
        {
            // Check if the user has a temporary password stored (hashed)
            var passwordHash = user.PasswordHash;
            // You can store a flag in a custom user field if needed
            // instead of relying solely on password complexity
            return passwordHash.StartsWith("$TEMP$"); // Replace with your logic
        }

        [HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
