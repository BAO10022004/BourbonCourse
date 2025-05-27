using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_KhoaHoc.Models
{
    public class Accountcourse
    {
        public long id { get; set; }
        public Account username { get; set; }
        public TeacherCourse tearcherCourse { get; set; }

    }
}
