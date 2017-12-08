using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CoStartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CoEndDate { get; set; }

        public string Description { get; set; }

       

        public IEnumerable<Modul> Moduls { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}