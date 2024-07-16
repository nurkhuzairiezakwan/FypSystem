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
    public class EvaluatorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public EvaluatorController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> ProposalList()
        {
            var userId = _userManager.GetUserId(User);
            var users = _userManager.Users.ToList();
            var proposalVM = new List<ProposalVM>();
            var evaluatorNames = users.ToDictionary(u => u.Id, u => u.user_name);

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Student"))
                {
                    var student = _unitOfWork.Students.Get(s => (s.s_evaluator1 == userId || s.s_evaluator2 == userId) && s.Id == user.Id);
                    if (student != null)
                    {
                        var proposal = _unitOfWork.Proposals.Get(p => p.s_id == student.s_id);
                        var thisViewModel = new ProposalVM
                        {
                            p_id = proposal.p_id,
                            s_id = student.s_id,
                            s_user = student.s_user,
                            s_evaluator1 = evaluatorNames.ContainsKey(student.s_evaluator1) ? evaluatorNames[student.s_evaluator1] : student.s_evaluator1,
                            s_evaluator2 = evaluatorNames.ContainsKey(student.s_evaluator2) ? evaluatorNames[student.s_evaluator2] : student.s_evaluator2,
                            s_SV = student.s_SV,
                            st_id = proposal?.st_id,
                            p_evaluator1_comment = proposal?.p_evaluator1_comment,
                            p_evaluator2_comment = proposal?.p_evaluator2_comment,
                            p_title = proposal?.p_title,
                            pt_ID = user.pt_ID
                        };
                        proposalVM.Add(thisViewModel);
                    }
                }
            }
            return View(proposalVM);
        }

        public async Task<IActionResult> ViewDetails(int id)
        {
            var proposal = _unitOfWork.Proposals.GetFirstOrDefault(p => p.s_id == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        [HttpPost]
        public async Task<IActionResult> ViewDetails(int s_id, string st_id, string? comment)
        {
            var userId = _userManager.GetUserId(User);
            var proposal = _unitOfWork.Proposals.GetFirstOrDefault(p => p.s_id == s_id);

            if (proposal == null)
            {
                return NotFound();
            }

            proposal.st_id = st_id;

            var student = _unitOfWork.Students.Get(s => s.s_id == s_id);

            if (student.s_evaluator1 == userId)
            {
                if (comment != null)
                {
                    proposal.p_evaluator1_comment = comment;
                }
            }
            else if (student.s_evaluator2 == userId)
            {
                if (comment != null)
                {
                    proposal.p_evaluator2_comment = comment;
                }
            }

            _unitOfWork.Proposals.Update(proposal);
            _unitOfWork.Save();

            return RedirectToAction("ProposalList");
        }
    }
}
