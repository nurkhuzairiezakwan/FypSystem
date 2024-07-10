using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LecturerController : Controller
    {
        public IActionResult LecturerList()
        {
            return View();
        }
    }
}
