using LexiconLMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CoStartDate { get; set; }
        public DateTime CoEndDate { get; set; }

        public string Description { get; set; }

        public Modul Modul { get; set; }

        public IEnumerable<Modul> Moduls { get; set; }
        public List<Course> Course { get; internal set; }
    }
}