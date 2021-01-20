namespace FMS.ServiceLayer.Dtos
{
    public class LocationListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalCount { get; set; }
        public int TotalStockQuantity { get; set; }
        public int TotalReservedQuantity { get; set; }
    }
}
