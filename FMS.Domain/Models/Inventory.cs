namespace FMS.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set;}

        //NB! int? - temp, must be -> int
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public int ReservedQuantity { get; set; }
        public int StockQuantity { get; set; }
    }
}
