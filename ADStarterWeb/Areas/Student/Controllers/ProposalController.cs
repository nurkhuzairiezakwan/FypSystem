using ADStarter.DataAccess.Repository;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace ADStarterWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class ProposalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProposalController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public IActionResult AddProposal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProposal(Proposal proposal, IFormFile? file)
        {
            var userId = _userManager.GetUserId(User);
            var student = _unitOfWork.Student.GetFirstOrDefault(s => s.User.Id == userId);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            proposal.s_id = student.s_id;
            HandleFileUpload(proposal, file);

            _unitOfWork.Proposal.Add(proposal);
            _unitOfWork.Save();

            return RedirectToAction("Proposal", "Proposal");
        }

        public IActionResult Proposal()
        {
            var userId = _userManager.GetUserId(User);
            var student = _unitOfWork.Student.GetFirstOrDefault(s => s.User.Id == userId);

            if (student == null)
            {
                // Handle case where student is not found
                // Redirect to an error page or return an appropriate response
                return RedirectToAction("SV", "SV", new { area = "Student" });
            }
            ViewBag.svId = student.s_SV ?? null;
            ViewBag.svStatus = student.s_statusSV;
            ViewBag.userId = userId;

            var proposal = _unitOfWork.Proposal.GetFirstOrDefault(p => p.Student.User.Id == userId);

            if (proposal == null)
            {
                proposal = new Proposal();
            }

            return View(proposal);
        }

        public IActionResult ResubmitProposal(int id)
        {

            var proposal = _unitOfWork.Proposal.GetFirstOrDefault(p => p.p_id == id);
            if (proposal == null || !(proposal.st_id == "Accepted with Conditions" || proposal.st_id == "Rejected"))
            {
                return RedirectToAction("Proposal");
            }
            ViewBag.userId = id;
            return View(proposal);
        }

        [HttpPost]
        public IActionResult ResubmitProposal(Proposal proposal, IFormFile? file,int p_id)
        {

            var existingProposal = _unitOfWork.Proposal.GetFirstOrDefault(p => p.p_id == p_id);
            if (existingProposal == null)
            {
                return NotFound("Proposal not found");
            }

            HandleFileUpload(existingProposal, file);
            existingProposal.p_title = proposal.p_title;
            existingProposal.IsResubmission = true;
            existingProposal.st_id = "Pending"; // Reset status to pending for resubmission

            _unitOfWork.Save();

            return RedirectToAction("Proposal");
        }

        private void HandleFileUpload(Proposal proposal, IFormFile? file)
        {
            if (file != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string p_file = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string p_filePath = Path.Combine(wwwRootPath, "uploads");

                using (var fileStream = new FileStream(Path.Combine(p_filePath, p_file), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                proposal.p_file = @"\uploads\" + p_file;
            }
        }
    }
}
