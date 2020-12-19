namespace FMS.ServiceLayer.Dtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int FreeQuantity => (StockQuantity - ReservedQuantity);
    }
}
