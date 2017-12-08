using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Display(Name = "Aktivitet")]
        public string ActivityName { get; set; }

        [Display(Name = "Aktivitetsstart")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActivityStart { get; set; }

        [Display(Name = "Aktivitetsslut")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActivityEnd { get; set; }

        [Display(Name = "Beskrivning")]
        public string ActivityDescription { get; set; }

        // [ForeignKey("ActivityTypeId")]
        [Display(Name = "Aktivitetstyp")]
        public int ActivityTypeId { get; set; }


        //[ForeignKey("CourseId")]
        public int ModuleId { get; set; }

        public virtual Modul Module { get; set; }

        [Display(Name = "Aktivitetstyp")]
        public virtual ActivityType ActivityType { get; set; }
    }
}