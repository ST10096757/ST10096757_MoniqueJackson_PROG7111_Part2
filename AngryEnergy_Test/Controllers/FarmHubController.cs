using Microsoft.AspNetCore.Mvc;

namespace AngryEnergy_Test.Controllers
{
    public class FarmHubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
