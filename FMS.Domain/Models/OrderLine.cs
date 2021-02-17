using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int OrderedQuantity { get; set; }
        public int InvoicedQuantity { get; set; }
        public int ReservedQuantity { get; set; }

        public DateTime? CreatedOn { get; set; }


        //--- legacy system fields ---
        public int FMS_tellridaid { get; set; }
    }
}
