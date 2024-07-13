using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDBContext _db;

        public CourseController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager, ApplicationDBContext db)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _db = db;
        }
        public IActionResult CourseList()
        {
            List<Course> course = _unitOfWork.Course.GetAll().ToList();
            return View(course);
            //return View();
        }
        public IActionResult Upsert(int? Id)
        {
            var course = new Course();
            if (Id == null || Id == 0)
            {
                return View(course);
            }
            else
            {
                course = _unitOfWork.Course.Get(u => u.course_ID == Id);
                return View(course);
            }
            ViewBag.UserId = Id ?? 0;
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(Course obj, int courseId)
        {

            if (ModelState.IsValid)
            {
                var course = _unitOfWork.Course.Get(filter: c => c.course_ID == courseId);
                if (course == null)
                {
                    _unitOfWork.Course.Add(obj);
                }
                else
                {
                    course.course_desc = obj.course_desc;
                    course.course_code = obj.course_code;
                    course.course_count = obj.course_count;
                    _unitOfWork.Course.Update(course);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product added successfully";
                return RedirectToAction("CourseList");
            }
            else
            {
                return View();
            }


        }
        #region API CALLS

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var courseDelete = _unitOfWork.Course.Get(c => c.course_ID == id);
            if (courseDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Course.Remove(courseDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
