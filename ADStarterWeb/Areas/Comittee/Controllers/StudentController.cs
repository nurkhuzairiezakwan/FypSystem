using Microsoft.AspNetCore.Mvc;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using ADStarter.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ADStarter.Models.ViewModels;

namespace ADStarterWeb.Areas.Comittee.Controllers
{
    [Area("Comittee")]
   
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(IUnitOfWork unitOfWork, ApplicationDBContext context, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
        }

        // Action to list students with user details
        public async Task<IActionResult> ListStudents()
        {
            var students = await _context.Students
                .Include(s => s.User) // Include User navigation property
                .Where(s => s.s_statusSV == "Pending" && s.s_SV != null) // Filter students
                .ToListAsync();

            var studentViewModels = new List<StudentStatusUpdateViewModel>();

            foreach (var student in students)
            {
                var supervisor = await _userManager.FindByIdAsync(student.s_SV);

                var viewModel = new StudentStatusUpdateViewModel
                {
                    s_id = student.s_id,
                    s_SV = supervisor != null ? supervisor.user_name : "Data not found",
                    s_statusSV = student.s_statusSV,
                    s_academic_session = student.s_academic_session,
                    s_semester = student.s_semester,
                    UserName = student.User.user_name,
                    UserMatric = student.User.user_matric
                };

                studentViewModels.Add(viewModel);
            }

            return View(studentViewModels);
        }


        // Action to show update status page
        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int studentId)
        {
            var student = await _context.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.s_id == studentId);

            if (student == null)
            {
                return NotFound();
            }

            // Fetch supervisor's name
            var supervisor = await _userManager.FindByIdAsync(student.s_SV);
            var supervisorName = supervisor != null ? supervisor.user_name : "Data not found";

            var viewModel = new StudentStatusUpdateDetailViewModel
            {
                s_id = student.s_id,
                s_SV = student.s_SV,
                s_statusSV = student.s_statusSV,
                s_academic_session = student.s_academic_session,
                s_semester = student.s_semester,
                UserName = student.User.user_name,
                UserMatric = student.User.user_matric
            };

            ViewBag.SupervisorName = supervisorName;

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateStatus(StudentStatusUpdateDetailViewModel model, IFormFile file)
        {
            var student = await _context.Students.FindAsync(model.s_id);
            if (student == null)
            {
                return NotFound();
            }

            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                student.s_SVagreement = "/uploads/" + file.FileName; // Save the relative file path to the database
            }

            student.s_statusSV = "Approved"; // Update the status to "Approved"
            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("ListStudents");
        }

        // Action to list students with supervisor and assign evaluators
        public IActionResult ListStudentsWithSupervisor()
        {
            // Fetch students with supervisor
            var studentsWithSupervisor = _context.Students
                .Include(s => s.User)
                .Where(s => s.s_SV != null)
                .ToList();

            // Create a list of ViewModel for display
            List<StudentAssignmentViewModel> viewModelList = new List<StudentAssignmentViewModel>();

            foreach (var student in studentsWithSupervisor)
            {
                // Retrieve supervisor's ID and name
                var supervisorId = student.s_SV;
                var supervisorName = _userManager.FindByIdAsync(supervisorId).Result.user_name;

                // Determine project type
                var projectType = student.User.pt_ID;

                // Determine available evaluators (lecturers)
                var availableEvaluators = _userManager.GetUsersInRoleAsync("Lecturer").Result
                    .Select(u => u.user_name)
                    .ToList();

                // Exclude supervisor from evaluators
                availableEvaluators.Remove(supervisorName);

                // Create ViewModel instance
                var viewModel = new StudentAssignmentViewModel
                {
                    StudentId = student.s_id,
                    StudentName = student.User.user_name,
                    ProjectType = projectType,
                    SupervisorId = supervisorId,
                    SupervisorName = supervisorName,
                    AvailableEvaluators = availableEvaluators
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }
    }
}