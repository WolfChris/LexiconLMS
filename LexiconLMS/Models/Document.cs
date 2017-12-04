using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserId { get; set; }
        public DateTime Deadline { get; set; }
        public string FileName { get; set; }

        public int DocumentTypeId { get; set; }
        public int? CourseId { get; set; }
        public int? ModulId { get; set; }
        public int? ActivityId { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual Course Course { get; set; }
        public virtual Modul Modul { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ApplicationUser User{get; set; }
    }
}