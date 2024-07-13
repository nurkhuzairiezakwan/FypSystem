using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ADStarter.Models;
using ADStrater.Models;
using ADStarter.DataAccess.Data;

namespace ADStarterWeb.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    public class SupervisorController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SupervisorController(ApplicationDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> StudentList(string semester, string academicSession)
        {
            var userId = _userManager.GetUserId(User);
            var students = await _context.Students
                .Include(s => s.User)
                .Include(s => s.Proposals)
                .Where(s => s.s_SV == userId && s.s_semester == semester && s.s_academic_session == academicSession)
                .ToListAsync();

            return View(students);
        }

        public async Task<IActionResult> ProposalDetails(int id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Student)
                .ThenInclude(s => s.User)
                .FirstOrDefaultAsync(p => p.p_id == id);

            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupervisorComment(int id, string comment)
        {
            var proposal = await _context.Proposals.FindAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }

            proposal.p_sv_comment = comment;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ProposalDetails), new { id = id });
        }
    }
}
