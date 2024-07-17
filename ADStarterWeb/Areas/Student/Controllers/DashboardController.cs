using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {  
                return View();
        }
    }
}
