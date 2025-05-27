using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_KhoaHoc.Models
{
    public class TeacherCourse
    {
        public int id { get; set; }
        public Teacher teacher { get; set; }

        public Course course { get; set; }

    }
}
