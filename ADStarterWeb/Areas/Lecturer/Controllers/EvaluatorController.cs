using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    public class EvaluatorController : Controller
    {
        public IActionResult ProposalList()
        {
            return View();
        }
    }
}