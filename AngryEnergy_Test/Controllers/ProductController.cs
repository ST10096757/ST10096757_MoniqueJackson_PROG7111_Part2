using AngryEnergy_Test.Data;
using AngryEnergy_Test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AngryEnergy_Test.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class ProductController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly ApplicationDbContext _context;

		//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="context"></param>
		public ProductController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
		}

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        [HttpGet]
        public IActionResult Index(DateTime? startDate, DateTime? endDate, string category)
        {
            var products = _context.ProductsDbSet.AsQueryable();

            if (startDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate <= endDate.Value);
            }

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            // Get unique categories
            var categories = _context.ProductsDbSet
                                     .Select(p => p.Category)
                                     .Distinct()
                                     .ToList();

            // Create a list of SelectListItem objects
            var categoryItems = categories.Select(c => new SelectListItem
            {
                Text = c,
                Value = c,
                Selected = c == category // Set selected item based on current category
            }).ToList();

            // Pass the filter values and categories to the view
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.Category = category;
            ViewBag.Categories = categoryItems;


            return View(products.ToList());
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        [HttpPost]
        public async Task<IActionResult> Add(ProductModel product)
        {
			// Retrieve the current user's UserId
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			// Create a new ProductModel instance
			var newProduct = new ProductModel()
			{
				Id = Guid.NewGuid(),
				UserID = userId, // Assign the UserId
				Name = product.Name,
				Category = product.Category,
				ProductionDate = product.ProductionDate,
			};

			// Add the newProduct to the ProductsDbSet and save changes
			await _context.ProductsDbSet.AddAsync(newProduct);
			await _context.SaveChangesAsync();

			return RedirectToAction("Add");
		}

    }
}
    
