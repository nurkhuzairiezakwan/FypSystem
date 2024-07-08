using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Student.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
