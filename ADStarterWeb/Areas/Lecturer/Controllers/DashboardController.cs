using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
