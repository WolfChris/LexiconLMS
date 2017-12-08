using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class ActivityType
    {
        public int Id { get; set; }

        [Display(Name = "Aktivitetstyp")]
        public string ActivityTypeName { get; set; }

        [Display(Name = "Beskrivning")]
        public string ActivityTypeDescription { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}