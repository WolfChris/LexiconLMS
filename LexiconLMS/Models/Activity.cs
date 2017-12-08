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
        public string ActivityName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActivityStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActivityEnd { get; set; }
        public string ActivityDescription { get; set; }

       // [ForeignKey("ActivityTypeId")]
        public int ActivityTypeId { get; set; }


        //[ForeignKey("CourseId")]
        public int ModuleId { get; set; }

        public virtual Modul Module { get; set; }
        public virtual ActivityType ActivityType { get; set; }
    }
}