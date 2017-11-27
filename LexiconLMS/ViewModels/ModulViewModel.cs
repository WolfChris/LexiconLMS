using LexiconLMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.ViewModels
{
    public class ModulViewModel
    {

        public int Id { get; set; }
        public string ModulName { get; set; }
        public string ModulDescription { get; set; }
        public DateTime ModulStart { get; set; }
        public DateTime ModulEnd { get; set; }


        public int Courseid { get; set; }
        [ForeignKey("Courseid")]
        public Course Course { get; set; }

        public ICollection<Course> Courses { get; set; }

    }
}