using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Location Location { get; set; }

        public int? ToFromLocationId { get; set; }
        public Location ToFromLocation { get; set; }

        public int? SourceDocumentId { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? BillingAddressId { get; set; }
        [ForeignKey(nameof(BillingAddressId))]
        public CustomerAddress BillingAddress { get; set; }

        public int? ShippingAddressId { get; set; }
        [ForeignKey(nameof(ShippingAddressId))]
        public CustomerAddress ShippingAddress { get; set; }

        public int PaymentDays { get; set; }

        [MaxLength(50)]
        public string DeliveryTermName { get; set; }
        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }
        public DateTime? CreatedOn { get; set; }

        public List<DocumentLine> DocumentLines { get; set; }


        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }

        [MaxLength(8)]
        public string FMS_doknr { get; set; }

        [MaxLength(6)]
        public string FMS_skood { get; set; }

        [MaxLength(2)]
        public string FMS_lkoodv { get; set; }

        [MaxLength(2)]
        public string FMS_lkoods { get; set; }

        public int FMS_dokid { get; set; }
    }
}
