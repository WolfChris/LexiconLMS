using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Modul
    {
        public int Id { get; set; }
        public string ModulName { get; set; }
        public string ModulDescription { get; set; }
        public DateTime ModulStart { get; set; }
        public DateTime ModulEnd { get; set; }

       
    }
}