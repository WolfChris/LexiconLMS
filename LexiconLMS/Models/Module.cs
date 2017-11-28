using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public DateTime MStartDate { get; set; }
        public DateTime MEndDate { get; set; }

        public Course Course { get; set; }
    }
}