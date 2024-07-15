using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models.ViewModels;
using ADStarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                if (roles.Contains("Committee") || roles.Contains("Lecturer"))
                {
                    var course = await _unitOfWork.Course.GetByIdAsync(user.course_ID);
                    var thisViewModel = new LecturerVM
                    {
                        user_IC = user.user_IC,
                        user_name = user.user_name,
                        user_address = user.user_address,
                        Email = user.Email,
                        User = user.Id,
                        user_contact = user.user_contact,
                        user_matric = user.user_matric,
                        pt_ID = user.pt_ID,
                        course_name = course.course_desc,
                        Roles = roles
                    };
                    lecturerVM.Add(thisViewModel);
                }
            }

            return View(lecturerVM);
        }
        public async Task<IActionResult> ViewDetails(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var course = await _unitOfWork.Course.GetByIdAsync(user.course_ID);
            var model = new LecturerVM
            {
                user_IC = user.user_IC,
                user_name = user.user_name,
                user_address = user.user_address,
                Email = user.Email,
                User = user.Id,
                user_contact = user.user_contact,
                user_matric = user.user_matric,
                pt_ID = user.pt_ID,
                course_name = course.course_desc,
                Roles = roles
            };

            return View(model);
        }
        public async Task<IActionResult> Update(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var rolename = roles[0];
            var role = await _roleManager.FindByNameAsync(rolename);
            var course = await _unitOfWork.Course.GetByIdAsync(user.course_ID);
            var model = new LecturerVM
            {
                user_IC = user.user_IC,
                user_name = user.user_name,
                user_address = user.user_address,
                Email = user.Email,
                User = user.Id,
                user_contact = user.user_contact,
                user_matric = user.user_matric,
                pt_ID = user.pt_ID,
                course_ID = user.course_ID,
                SelectedRoleId = role.Id,
                Courses = _unitOfWork.Course.GetAll().Select(c => new SelectListItem 
                {   Value = c.course_ID.ToString(), 
                    Text = c.course_desc
                }),
                RolesList = _roleManager.Roles.Select(r => new SelectListItem 
                {   Value = r.Id, 
                    Text = r.Name
                })
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(LecturerVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.User);
                var course = await _unitOfWork.Course.GetByIdAsync(user.course_ID);

                var existingUserByEmail = await _userManager.FindByEmailAsync(model.Email);
                if (existingUserByEmail != null && existingUserByEmail.Id != user.Id)
                {
                    ModelState.AddModelError("Email", "Email is already in use.");
                }

                // Check if IC number is already used
                var existingUserByIC = _userManager.Users.FirstOrDefault(u => u.user_IC == model.user_IC && u.Id != user.Id);
                if (existingUserByIC != null)
                {
                    ModelState.AddModelError("user_IC", "IC number is already in use.");
                }

                // Check if phone number is already used
                var existingUserByPhone = _userManager.Users.FirstOrDefault(u => u.user_contact == model.user_contact && u.Id != user.Id);
                if (existingUserByPhone != null)
                {
                    ModelState.AddModelError("user_contact", "Phone number is already in use.");
                }

                // Check if matric number is already used
                var existingUserByMatric = _userManager.Users.FirstOrDefault(u => u.user_matric == model.user_matric && u.Id != user.Id);
                if (existingUserByMatric != null)
                {
                    ModelState.AddModelError("user_matric", "Matric number is already in use.");
                }
                if (user == null)
                {
                    return NotFound();
                }

                user.user_IC = model.user_IC;
                user.user_name = model.user_name;
                user.user_address = model.user_address;
                user.Email = model.Email;
                user.user_contact = model.user_contact;
                user.user_matric = model.user_matric;
                user.course_ID = model.course_ID;
                user.pt_ID = model.pt_ID;


                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    foreach (var error in updateResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    // Update roles if necessary
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (!removeRolesResult.Succeeded)
                    {
                        foreach (var error in removeRolesResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    var role = await _roleManager.FindByIdAsync(model.SelectedRoleId);
                    var addRoleResult = await _userManager.AddToRoleAsync(user,role.Name);
                    if (!addRoleResult.Succeeded)
                    {
                        foreach (var error in addRoleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                    if (updateResult.Succeeded && removeRolesResult.Succeeded && addRoleResult.Succeeded)
                    {
                        return RedirectToAction("LecturerList");
                    }
                }
            }

            // If ModelState is not valid or any operation fails, return the view with errors
            return View(model);
        }

        #region API CALLS
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Json(new { success = true, message = "User deleted successfully" });
            }

            return Json(new { success = false, message = "Error while deleting user" });
        }
        #endregion
    }
}
