using Microsoft.AspNetCore.Mvc;
using Web_KhoaHoc.Models;
using Web_KhoaHoc.Service;

namespace Web_KhoaHoc.Controllers
{
    public class HomeController : Controller
    {
        
        public async Task<IActionResult> Main(int? subjectId, string? searchTerm, int courseId = 1)
        {
            ViewBag.Course = await new CourseService().GetCourses();
            ViewBag.Subject = await new SujectService().GetAll();
            List<TeacherCourse> teacherCourses = new List<TeacherCourse>();
            foreach(var i in ViewBag.Course)
            {
                ViewData[$"course{i.id}"] = teacherCourses.Where(x => x.course.id == i.id).ToList();
            }

            teacherCourses = await new TeacherCourseService().GetAll();

            if (subjectId != null)
            {
                Subject subject = (await new SujectService().GetAll()).FirstOrDefault(x => x.id == subjectId);
                teacherCourses = teacherCourses
                                .Where(x => x.teacher.subject.id == subjectId).ToList();
            }
            if (searchTerm != null)
            {
                teacherCourses = teacherCourses
                                .Where(x => x.teacher.teacherName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            if(courseId != 0)
            {
                teacherCourses = teacherCourses
                                .Where(x => x.course.id == courseId).ToList();
            }
            ViewBag.Teacher = teacherCourses;
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> MyCourse()
        {
            if(Session.Session.currentAccount == null)
            {
                return RedirectToAction("Login", "Account");
            }
            //get teacger course
            var tc = await new AccountCourseService().GetAccountcourseByAccount(Session.Session.currentAccount.username);
            //get course
            ViewBag.Course = tc.Select(x => x.tearcherCourse.course).ToList();
            //get teacher
            ViewBag.Teacher = tc.Select(x => x.tearcherCourse).ToList();
            //get subject
           
            ViewBag.Subject = tc.Select(x => x.tearcherCourse.teacher.subject).ToList();
            
            return View();
        }
    }
}
