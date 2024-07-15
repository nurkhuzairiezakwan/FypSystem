using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var student = _unitOfWork.Student.Get(filter: a => a.User.Id == user.Id);
            if (student == null)
            {
                student = new ADStarter.Models.Student
                {
                    s_user = user.user_name,
                    User = user
                };

                // Save the new student details
                _unitOfWork.Student.Add(student);
                _unitOfWork.Save();
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
