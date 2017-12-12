using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class AssigmentViewModel
    {
        public int Id { get; set; }
        
        public DateTime ActivityStart { get; set; }
        public DateTime ActivityEnd { get; set; }
        public string ActivityDescription { get; set; }

        public int studentid { get; set; }

        public int modulid { get; set; }


    }
}