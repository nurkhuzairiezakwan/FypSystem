using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Parent.Controllers
{
    [Area("LandingPage")]
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

