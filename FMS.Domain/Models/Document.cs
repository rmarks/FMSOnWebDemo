using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Document
    {
        public int Id { get; set; }
        
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        
        [Required, MaxLength(10)]
        public string DocumentNo { get; set; }
        public DateTime DocumentDate { get; set; }
        
        public int LocationId { get; set; }
        public int? ToFromLocationId { get; set; }
        public int? SourceDocumentId { get; set; }
        public DateTime CreatedOn { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }

        [MaxLength(8)]
        public string FMS_doknr { get; set; }

        [MaxLength(6)]
        public string FMS_skood { get; set; }
    }
}
