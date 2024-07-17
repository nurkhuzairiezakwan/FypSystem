using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using ADStarter.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADStarterWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class SVController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public SVController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public IActionResult SV()
        {
            var userId = _userManager.GetUserId(User);

            // Fetch the student data for the current user
            var student = _unitOfWork.Student.GetFirstOrDefault(s => s.User == userId);

            // If no student is found, initialize a new student object
            if (student == null)
            {
                student = new ADStarter.Models.Student();
            }

            // Fetch the supervisor's details if the supervisor ID is not null
            string supervisorName = null;
            if (!string.IsNullOrEmpty(student.s_SV))
            {
                var supervisor = _userManager.Users.FirstOrDefault(u => u.Id == student.s_SV);
                if (supervisor != null)
                {
                    supervisorName = supervisor.user_name; // Assuming the username is stored in UserName property
                }
            }

            var viewModel = new StudentVM
            {
                Student = student,
                SupervisorName = supervisorName
            };

            ViewBag.userId = userId;
            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> AddSupervisor(string id)
        {
            var users = await _userManager.GetUsersInRoleAsync("Lecturer");
            var lecturerVM = new List<StudentVM>();

            foreach (var user in users)
            {
                var thisViewModel = new StudentVM
                {
                    User = user,
                    user_name = user.user_name,
                };
                lecturerVM.Add(thisViewModel);
            }
            ViewBag.userId = id;

            return View(lecturerVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupervisor(ADStarter.Models.Student student, string semester, string academicSession, string id, string userId)
        {
            if (string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(academicSession) || string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            if (student == null)
            {
                return BadRequest("Student object cannot be null");
            }

            var user = _userManager.GetUserId(User);
            
            
            if (user == null)
            {
                return Unauthorized();
            }

            // Assign supervisor and other details to the student
            student.s_SV = id;
            student.s_semester = semester;
            student.s_academic_session = academicSession;
            student.User = userId;

            try
            {
                // Update the Student entity
                _unitOfWork.Student.Add(student);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            return RedirectToAction("SV", "SV", new { area = "Student" });
        }



    }
}
