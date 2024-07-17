using Microsoft.AspNetCore.Mvc;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using ADStarter.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ADStarter.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ADStarterWeb.Areas.Comittee.Controllers
{
    [Area("Comittee")]
    public class ProposalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProposalController(IUnitOfWork unitOfWork, ApplicationDBContext context, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
        }

        // Action to list all proposals with student names
        public async Task<IActionResult> List()
        {
            List<Proposal> proposals = await _context.Proposals
                .Include(p => p.Student) // Include Student entity
                .ThenInclude(s => s.User) // Then include ApplicationUser entity
                .ToListAsync();

            return View(proposals);
        }

        // Action to list proposals based on conditions
        public async Task<IActionResult> ListProposals()
        {
            var proposals = await _context.Proposals
                .Include(p => p.Student)
                .ThenInclude(s => s.User)
                .Where(p => (p.st_id == "Pending" && p.Student.s_evaluator1 == null && p.Student.s_evaluator2 == null) ||
                            p.st_id == "Rejected" || p.st_id == "Accepted With Condition")
                .ToListAsync();

            var proposalViewModels = proposals.Select(p => new ProposalAssignmentViewModel
            {
                p_id = p.p_id,
                s_id = p.s_id,
                StudentName = p.Student.User.user_name,
                p_title = p.p_title,
                p_file = p.p_file,
                st_id = p.st_id,
                s_SV = p.Student.s_SV,
                s_evaluator1 = p.Student.s_evaluator1,
                s_evaluator2 = p.Student.s_evaluator2,
                pt_ID = p.Student.User.pt_ID
            }).ToList();

            return View(proposalViewModels);
        }

        // Action to show assign evaluators page
        [HttpGet]
        public async Task<IActionResult> AssignEvaluators(int proposalId)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Student)
                .ThenInclude(s => s.User)
                .FirstOrDefaultAsync(p => p.p_id == proposalId);

            if (proposal == null)
            {
                return NotFound();
            }

            // Retrieve the supervisor ID
            var supervisorId = proposal.Student.s_SV;

            // Get the list of all evaluators who are lecturers
            var evaluators = await _userManager.GetUsersInRoleAsync("Lecturer");

            // Filter out the supervisor from the list of evaluators
            var availableEvaluators = evaluators
                .Where(e => e.Id != supervisorId)
                .Select(e => new SelectListItem
                {
                    Value = e.Id,
                    Text = e.user_name
                })
                .ToList();

            var viewModel = new ProposalAssignmentViewModel
            {
                p_id = proposal.p_id,
                s_id = proposal.s_id,
                StudentName = proposal.Student.User.user_name,
                p_title = proposal.p_title,
                p_file = proposal.p_file,
                st_id = proposal.st_id,
                s_SV = proposal.Student.s_SV,
                s_evaluator1 = proposal.Student.s_evaluator1,
                s_evaluator2 = proposal.Student.s_evaluator2,
                pt_ID = proposal.Student.User.pt_ID,
                AvailableEvaluators = availableEvaluators
            };

            return View(viewModel);
        }


        // Action to handle assign evaluators
        [HttpPost]
        public async Task<IActionResult> AssignEvaluators(ProposalAssignmentViewModel model)
        {
            var student = await _context.Students.FindAsync(model.s_id);
            if (student == null)
            {
                return NotFound();
            }

            // Update the evaluators
            student.s_evaluator1 = model.s_evaluator1;
            student.s_evaluator2 = model.s_evaluator2;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("ListProposals");
        }

    }
}
