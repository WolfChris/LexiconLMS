using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CoStartDate { get; set; }
        public DateTime CoEndDate { get; set; }

        public string Description { get; set; }
    }
}