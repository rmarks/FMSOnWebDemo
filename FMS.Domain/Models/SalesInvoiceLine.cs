using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class SalesInvoiceLine
    {
        public int Id { get; set; }

        public int SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int InvoicedQuantity { get; set; }
    }
}
