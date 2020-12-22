using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class SalesInvoice
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? BillingAddressId { get; set; }
        [ForeignKey(nameof(BillingAddressId))]
        public CustomerAddress BillingAddress { get; set; }

        public int? ShippingAddressId { get; set; }
        [ForeignKey(nameof(ShippingAddressId))]
        public CustomerAddress ShippingAddress { get; set; }

        [MaxLength(50)]
        public string DeliveryTermName { get; set; }
        public int PaymentDays { get; set; }
        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public IList<SalesInvoiceLine> SalesInvoiceLines { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }
        [MaxLength(8)]
        public string FMS_doknr { get; set; }
    }
}
