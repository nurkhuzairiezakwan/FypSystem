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
            var users = _userManager.Users.ToList();
            var studentVM = new List<StudentViewModels>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Student"))
                {
                    var student = _unitOfWork.Student.Get(s => s.s_SV == userId && s.Id == user.Id);
                    if (student != null)
                    {
                        var proposal = _unitOfWork.Proposal.Get(p => p.s_id == student.s_id);
                        var thisViewModel = new StudentViewModels
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
                            user_contact = user.user_contact,
                            st_id = proposal?.st_id // Use null conditional operator
                        };
                        studentVM.Add(thisViewModel);
                    }
                }
            }
            return View(studentVM);
        }

        public async Task<IActionResult> ReviewProposal(int id)
        {
            var proposal = _unitOfWork.Proposal.GetFirstOrDefault(p => p.s_id == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        [HttpPost]
        public async Task<IActionResult> ReviewProposal(int id, string comment)
        {
            Console.WriteLine("Form submitted: ID = " + id + ", Comment = " + comment);

            var proposal = _unitOfWork.Proposal.GetFirstOrDefault(p => p.p_id == id);
            if (proposal == null)
            {
                Console.WriteLine("Proposal not found");
                return NotFound();
            }

            if (comment != null)
            {
                proposal.p_sv_comment = comment;
                _unitOfWork.Proposal.Update(proposal);
                _unitOfWork.Save();
            }

            return RedirectToAction("StudentList");
        }

        public async Task<IActionResult> EvaluationDetails(int id)
        {
            var proposal = _unitOfWork.Proposal.GetFirstOrDefault(p => p.s_id == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }
    }
}
