using Microsoft.AspNetCore.Mvc;
using Web_KhoaHoc.Models;
using Web_KhoaHoc.Service;

namespace Web_KhoaHoc.Controllers
{
    public class TeacherCourseController : Controller
    {
        public async Task<IActionResult> Index(int teacherCourseId)
        {
            ViewBag.Class = await new ClassService().GetByTeacherCourse(teacherCourseId);
            return View();
        }
    }
}
