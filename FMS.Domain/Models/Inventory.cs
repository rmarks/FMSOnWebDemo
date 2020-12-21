namespace FMS.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set;}

        //NB! int? - temp, must be -> int
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public int ReservedQuantity { get; set; }
        public int StockQuantity { get; set; }
    }
}
