using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Modul
    {
        public int Id { get; set; }

        [Display(Name = "Modulnamn")]
        public string ModulName { get; set; }

        [Display(Name = "Beskrivning")]
        public string ModulDescription { get; set; }

        [Display(Name = "Startdatum modul")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModulStart { get; set; }

        [Display(Name = "Slutdatum modul")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModulEnd { get; set; }
       
        public int Courseid { get; set; }
        [ForeignKey("Courseid")]
        public Course Course { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

    }
}