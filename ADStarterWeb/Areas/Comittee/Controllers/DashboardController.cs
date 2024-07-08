using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Comittee.Controllers
{
    [Area("Comittee")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
