using AngryEnergy_Test.Data;
using AngryEnergy_Test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AngryEnergy_Test.Controllers
{
    [Authorize(Roles = "Employee")]
    public class FarmerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public FarmerController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Add(string email, string firstName, string lastName, string contact, FarmerModel farmer)
        {
            email = farmer.UserModel.Email;
            firstName = farmer.UserModel.FirstName;
            lastName = farmer.UserModel.LastName;
            contact = farmer.UserModel.Contact;

            if (!string.IsNullOrEmpty(email))
            {
                // Generate a temporary password
                var temporaryPassword = GenerateTemporaryPassword();
                // Create a new UserModel instance
                var user = new UserModel
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Contact = contact,
                };
                // Hash the temporary password before storing
                var passwordHash = _userManager.PasswordHasher.HashPassword(user, temporaryPassword);
               // var passbegin = "TEMP";
                user.PasswordHash = "$TEMP$" + passwordHash;

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    try
                    {
                        var farmerUser = new FarmerModel
                        {
                            ID = Guid.NewGuid(),
                            UserID = user.Id,
                            Address = farmer.Address,
                            FarmType = farmer.FarmType,
                        };

                        // No need to set FirstName, LastName, and Contact on user here (already set in UserModel)
                        TempData["TempPassword"] = temporaryPassword;




                        // Assign the user to the role
                        await _userManager.AddToRoleAsync(user, "Farmer");





                        // Add Farmer to the database
                        _context.FarmersDbSet.Add(farmerUser);
                        await _context.SaveChangesAsync();
                        // ...
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    // No need to sign in here as it's done in the Add method
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }

        private string GenerateTemporaryPassword()
        {
            // Generate a random temporary password
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpGet]
        public IActionResult Index(string category, string farmType)
        {
            IQueryable<FarmerModel> farmers = _context.FarmersDbSet.Include(f => f.UserModel);

            if (!string.IsNullOrEmpty(category))
            {
                // Join FarmerModel with ProductModel based on UserID
                farmers = farmers.Join(_context.ProductsDbSet,
                                        farmer => farmer.UserID,
                                        product => product.UserID,
                                        (farmer, product) => new { Farmer = farmer, Product = product })
                                 .Where(fp => fp.Product.Category == category)
                                 .Select(fp => fp.Farmer)
                                 .Distinct();
            }

            if (!string.IsNullOrEmpty(farmType))
            {
                farmers = farmers.Where(f => f.FarmType == farmType);
            }

            // Get unique categories
            var categories = _context.ProductsDbSet
                                     .Select(p => p.Category)
                                     .Distinct()
                                     .ToList();

            // Create a list of SelectListItem objects for categories
            var categoryItems = categories.Select(c => new SelectListItem
            {
                Text = c,
                Value = c,
                Selected = c == category // Set selected item based on current category
            }).ToList();

            // Get unique farm types
            var farmTypes = _context.FarmersDbSet
                                 .Select(f => f.FarmType)
                                 .Distinct()
                                 .ToList();

            // Create a list of SelectListItem objects for farm types
            var farmTypeItems = farmTypes.Select(ft => new SelectListItem
            {
                Text = ft,
                Value = ft,
                Selected = ft == farmType // Set selected item based on current farm type
            }).ToList();

            // Pass the filter values and dropdown items to the view
            ViewBag.Category = category;
            ViewBag.Categories = categoryItems;
            ViewBag.FarmType = farmType;
            ViewBag.FarmTypes = farmTypeItems;

            var model = farmers.ToList();

            return View(model);
        }
    }
}
