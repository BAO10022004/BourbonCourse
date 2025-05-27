using System.Collections.Generic;
using Web_KhoaHoc.Models;
namespace Web_KhoaHoc.Models
{
    public class CourseFilterViewModel
    {
        // Filter parameters
        public int? SubjectId { get; set; }
        public int? CourseId { get; set; }
        public string SearchTerm { get; set; }

        // Lists for dropdowns
        public List<Subject> AllSubjects { get; set; }
        public List<Course> AllCourses { get; set; }

        // Filtered results
        public List<SubjectTeachersGroup> FilteredSubjects { get; set; }

        public CourseFilterViewModel()
        {
            AllSubjects = new List<Subject>();
            AllCourses = new List<Course>();
            FilteredSubjects = new List<SubjectTeachersGroup>();
        }
    }

    public class SubjectTeachersGroup
    {
        public Subject Subject { get; set; }
        public List<TeacherWithCourses> Teachers { get; set; }

        public SubjectTeachersGroup()
        {
            Teachers = new List<TeacherWithCourses>();
        }
    }

    public class TeacherWithCourses
    {
        public Teacher Teacher { get; set; }
        public List<Course> Courses { get; set; }

        public TeacherWithCourses()
        {
            Courses = new List<Course>();
        }
    }
}