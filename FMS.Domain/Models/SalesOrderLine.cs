using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class SalesOrderLine
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        //NB! int? - temp, must be -> int
        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        //NB! int? - temp, must be -> int
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }

        public int OrderedQuantity { get; set; }
        public int InvoicedQuantity { get; set; }
        public int ReservedQuantity { get; set; }
    }
}
