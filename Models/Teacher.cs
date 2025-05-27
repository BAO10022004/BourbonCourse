using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_KhoaHoc.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string teacherName { get; set; }
        public Subject subject { get; set; }
    }
}
