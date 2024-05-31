using Microsoft.AspNetCore.Mvc;

namespace AngryEnergy_Test.Controllers
{
    public class MarketplaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
