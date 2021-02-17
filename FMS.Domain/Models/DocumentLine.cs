using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class DocumentLine
    {
        public int Id { get; set; }
        
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int? OrderLineId { get; set; }
        public OrderLine OrderLine { get; set; }

        public DateTime? CreatedOn { get; set; }


        //--- legacy system fields ---
        public int FMS_liikumid { get; set; }
    }
}
