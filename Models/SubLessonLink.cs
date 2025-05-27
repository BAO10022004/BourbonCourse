using Microsoft.Extensions.Options;
using System.IO;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System;
namespace Web_KhoaHoc.Models
{
    public class SubLessonLink
    {
        public int id { get; set; }

        public SubLesson subLesson { get; set; }


        public Type type { get; set; }


        public String link { get; set; }
    }
}
