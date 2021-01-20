namespace FMS.ServiceLayer.Dtos
{
    public class LocationListItemDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int TotalCount { get; set; }
        public int TotalStockQuantity { get; set; }
        public int TotalReservedQuantity { get; set; }
    }
}
