using Microsoft.Extensions.Options;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System;

namespace Web_KhoaHoc.Models
{
    public class SubLesson
    {
        public int id { get; set; }
        public String subLessonName { get; set; }
        public Lesson lesson { get; set; }
    }
}
