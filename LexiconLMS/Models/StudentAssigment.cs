using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class StudentAssigment

    {
     
            public int Id { get; set; }
            public string Name { get; set; }
          
            public DateTime TimeStamp { get; set; }
            public string UserId { get; set; }
           
            public string FileName { get; set; }

           
         
            public int? ModulId { get; set; }
            public int? ActivityId { get; set; }

           
            public virtual Modul Modul { get; set; }
            public virtual Activity Activity { get; set; }
            public virtual ApplicationUser User { get; set; }
        }
    }
