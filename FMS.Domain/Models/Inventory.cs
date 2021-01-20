namespace FMS.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set;}

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
    }
}
