using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentTypeDescription { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

    }
}