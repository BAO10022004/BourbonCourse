using Microsoft.AspNetCore.Mvc;
using Web_KhoaHoc.Models;
using Web_KhoaHoc.Service;

namespace Web_KhoaHoc.Controllers
{
    public class LessonController : Controller
    {
        private int classId;  
        public async Task<IActionResult> Index(int classId, int? sublessonId = 1)
        {
            var divisions = await new DivisionService().GetByClass(classId);
            ViewBag.Divisions = divisions;
            ViewBag.ClassId = classId;  
            if (divisions.Count == 0)
                return View();

            var allLessons = await new LessonService().GetAllLesson();
            var allSubLessons = await new LessonService().GetAllAllSublesson();
            var subLessonLinks = await new LessonService().GetSubLessonLinks();

            // Tìm SubLesson được chọn
            var selectedSubLesson = allSubLessons.FirstOrDefault(x => x.id == sublessonId);

            // Tìm Lesson chứa SubLesson được chọn
            var selectedLesson = selectedSubLesson != null
                ? allLessons.FirstOrDefault(l => l.id == selectedSubLesson.lesson.id)
                : null;

            // Tìm Division chứa Lesson được chọn
            var selectedDivision = selectedLesson != null
                ? divisions.FirstOrDefault(d => d.id == selectedLesson.division.id)
                : divisions.FirstOrDefault(); // Default to first division

            ViewBag.SelectedDivision = selectedDivision ?? new Division();
            ViewBag.Lessons = allLessons;
            ViewBag.SelectedLesson = selectedLesson ?? new Lesson();
            ViewBag.SubLessons = allSubLessons;
            ViewBag.SelectedSubLesson = selectedSubLesson ?? allSubLessons.FirstOrDefault();
            ViewBag.SubLessonLinks = subLessonLinks;

            return View();
        }

       
    }
}