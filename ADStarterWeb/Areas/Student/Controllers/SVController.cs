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
            var student = _unitOfWork.Student.GetFirstOrDefault(s => s.User.Id == userId);

            // If no student is found, initialize a new student object
            if (student == null)
            {
                student = new ADStarter.Models.Student();
            }

            // Fetch the supervisor's details if the supervisor ID is not null
            string supervisorName = null;
            string evaluatorName1 = null;
            string evaluatorName2 = null;
            if (!string.IsNullOrEmpty(student.s_SV))
            {
                var supervisor = _userManager.Users.FirstOrDefault(u => u.Id == student.s_SV);
                var evaluator1 = _userManager.Users.FirstOrDefault(u => u.Id == student.s_evaluator1);
                var evaluator2 = _userManager.Users.FirstOrDefault(u => u.Id == student.s_evaluator2);
                if (supervisor != null)
                {
                    supervisorName = supervisor.user_name; // Assuming the username is stored in UserName property
                }
                if (evaluator1 != null)
                {
                    evaluatorName1 = evaluator1.user_name; // Assuming the username is stored in UserName property
                }
                if (evaluator2 != null)
                {
                    evaluatorName2 = evaluator2.user_name; // Assuming the username is stored in UserName property
                }

            }

            var viewModel = new StudentViewModels
            {
                Student = student,
                SupervisorName = supervisorName,
                EvaluatorName1 = evaluatorName1,
                EvaluatorName2 = evaluatorName2

            };

            ViewBag.userId = userId;
            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> AddSupervisor(string id)
        {
            var users = await _userManager.GetUsersInRoleAsync("Lecturer");
            var lecturerVM = new List<StudentViewModels>();

            foreach (var user in users)
            {
                var thisViewModel = new StudentViewModels
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

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Retrieve the ApplicationUser using the userId
            var applicationUser = await _userManager.FindByIdAsync(userId);
            var test = applicationUser.Id;
            if (applicationUser == null)
            {
                return NotFound("User not found");
            }

            // Assign supervisor and other details to the student
            student.s_SV = id;
            student.s_semester = semester;
            student.s_academic_session = academicSession;
            //student.User = test;
            student.User = applicationUser;
            student.Id = userId;
            student.s_user = applicationUser.user_name; // Assign the user_name to s_user

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
