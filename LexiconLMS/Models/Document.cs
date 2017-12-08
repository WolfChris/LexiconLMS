using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Uppladdad")]
        public DateTime TimeStamp { get; set; }

        [Display(Name = "Användare")]
        public string UserId { get; set; }
        public DateTime? Deadline { get; set; }

        [Display(Name = "Filnamn")]
        public string FileName { get; set; }

        [Display(Name = "Dokumenttyp")]
        public int DocumentTypeId { get; set; }

        [Display(Name = "Kurs")]
        public int? CourseId { get; set; }

        [Display(Name = "Modul")]
        public int? ModulId { get; set; }

        [Display(Name = "Aktivitet")]
        public int? ActivityId { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual Course Course { get; set; }
        public virtual Modul Modul { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ApplicationUser User{get; set; }
    }
}