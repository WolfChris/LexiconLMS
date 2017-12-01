using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string ActivityTypeName { get; set; }
        public string ActivityTypeDescription { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}