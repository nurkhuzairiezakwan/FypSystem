using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using ADStarter.Models.ViewModels;

namespace ADStarterWeb.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    public class SupervisorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public SupervisorController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> StudentList(string semester, string academicSession)
        {
            var userId = _userManager.GetUserId(User);

            // if (!string.IsNullOrEmpty(semester))
            // {
            //     students = students.Where(s => s.s_semester == semester).ToList();
            // }

            // if (!string.IsNullOrEmpty(academicSession))
            // {
            //     students = students.Where(s => s.s_academic_session == academicSession).ToList();
            // }

            // var semesters = students.Select(s => s.s_semester).Distinct().ToList();
            // var academicSessions = students.Select(s => s.s_academic_session).Distinct().ToList();

            // ViewBag.Semesters = semesters;
            // ViewBag.AcademicSessions = academicSessions;

            var users = _userManager.Users.ToList();
            var studentVM = new List<StudentVM>();       

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Student"))
                {
                    var student = _unitOfWork.Students.Get(s => s.s_SV == userId && s.Id == user.Id);                    
                    var thisViewModel = new StudentVM
                    {
                        s_id = student.s_id,
                        s_user = student.s_user,
                        s_evaluator1 = student.s_evaluator1,
                        s_evaluator2 = student.s_evaluator2,
                        s_SV = student.s_SV,
                        s_statusSV = student.s_statusSV,
                        s_academic_session = student.s_academic_session,
                        s_semester = student.s_semester,
                        s_SVagreement = student.s_SVagreement,
                        user_IC = user.user_IC,
                        user_matric = user.user_matric,
                        user_name = user.user_name,
                        user_contact = user.user_contact
                    };
                    studentVM.Add(thisViewModel);
                }
            }
            return View(studentVM);
        }

        public async Task<IActionResult> ReviewProposal(int id)
        {
            var proposal = _unitOfWork.Proposals.GetFirstOrDefault(p => p.s_id == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        public async Task<IActionResult> EvaluationDetails(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupervisorComment(int id, string comment)
        {
            Console.WriteLine("AddSupervisorComment action hit.");

            var proposal = _unitOfWork.Proposals.GetFirstOrDefault(p => p.p_id == id);
            if (proposal == null)
            {
                Console.WriteLine("Proposal not found.");
                return NotFound();
            }

            Console.WriteLine("Fetched proposal: " + proposal.p_id);
            Console.WriteLine("Updating comment: " + comment);

            proposal.p_sv_comment = comment;
            _unitOfWork.Proposals.Update(proposal);

            try
            {
                Console.WriteLine("Saving changes.");
                _unitOfWork.Save();
                Console.WriteLine("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving supervisor comment: " + ex.Message);
                return View("Error");
            }

            return RedirectToAction(nameof(ReviewProposal), new { id = id });
        }
    }
}
