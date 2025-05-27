using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System;

namespace Web_KhoaHoc.Models
{
    public class Lesson
    {
        public int id { get; set; }

        public String lessonName { get; set; }
        public Division division { get; set; }
    }
}
