using ADStarter.Models;
using ADStarter.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ADStarter.Models.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ADStarter.DataAccess.Data;

namespace ADStarterWeb.Areas.Comittee.Controllers
{
    [Area("Comittee")]
    public class UserListController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDBContext _context; // Inject DbContext directly

        public UserListController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork, ApplicationDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // Action to list lecturers
        public async Task<IActionResult> ListLecturers()
        {
            var users = _userManager.Users.ToList();
            var lecturerViewModels = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Lecturer"))
                {
                    var viewModel = new UserRolesViewModel
                    {
                        Id = user.Id,
                        user_matric = user.user_matric,
                        user_name = user.user_name,
                        pt_ID = user.pt_ID,
                        course_desc = _context.Courses.FirstOrDefault(c => c.course_ID == user.course_ID)?.course_desc, // Retrieve course_desc directly
                        roles = roles
                    };
                    lecturerViewModels.Add(viewModel);
                }
            }

            return View(lecturerViewModels);
        }

        // Action to list students
        // Action to list students
        public async Task<IActionResult> ListStudents()
        {
            var users = _userManager.Users.ToList();
            var studentViewModels = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Student"))
                {
                    var viewModel = new UserRolesViewModel
                    {
                        Id = user.Id,
                        user_matric = user.user_matric,
                        user_name = user.user_name,
                        pt_ID = user.pt_ID ?? "Pending", // Set to "Pending" if pt_ID is null
                        course_desc = _context.Courses.FirstOrDefault(c => c.course_ID == user.course_ID)?.course_desc, // Retrieve course_desc directly
                        roles = roles
                    };
                    studentViewModels.Add(viewModel);
                }
            }

            return View(studentViewModels);
        }


        // GET: Edit user
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var viewModel = new UserRolesViewModel
            {
                Id = user.Id,
                user_matric = user.user_matric,
                user_name = user.user_name,
                pt_ID = user.pt_ID,
                course_desc = _context.Courses.FirstOrDefault(c => c.course_ID == user.course_ID)?.course_desc, // Retrieve course_desc directly
                roles = roles
            };

            return View(viewModel);
        }

        // POST: Edit user
        [HttpPost]
        public async Task<IActionResult> Edit(UserRolesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // If model state is not valid, return the view with the current model
                return View(model);
            }

            // Retrieve the user from UserManager based on model.Id
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return NotFound();
            }

            // Update properties based on the form submission
            user.pt_ID = model.pt_ID; // Update pt_ID based on the form input

            // Update user properties as needed and save changes
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Redirect to the appropriate list view after successful update
                if (model.roles.Contains("Lecturer"))
                {
                    return RedirectToAction("ListLecturers");
                }
                else if (model.roles.Contains("Student"))
                {
                    return RedirectToAction("ListStudents");
                }
            }

            // If update fails, add errors to ModelState and return the view with the model
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}
