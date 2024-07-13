using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models.ViewModels;
using ADStarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LecturerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public LecturerController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> LecturerList()
        {
            var users = _userManager.Users.ToList();
            var lecturerVM = new List<LecturerVM>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin") || roles.Contains("Student"))
                {
                    var thisViewModel = new LecturerVM
                    {
                        user_name = user.user_name,
                        user_matric = user.user_matric,
                        pt_ID = user.pt_ID,
                        Roles = roles
                    };
                    lecturerVM.Add(thisViewModel);
                }
            }

            return View(lecturerVM);
        }
    }
}
