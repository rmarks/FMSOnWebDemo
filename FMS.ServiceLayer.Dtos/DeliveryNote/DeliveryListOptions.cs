namespace FMS.ServiceLayer.Dtos
{
    public class DeliveryListOptions : PagedArgsBase
    {
        public int ToLocationTypeId { get; set; }
        public int ToLocationId { get; set; }

        public int FromLocationTypeId { get; set; }
        public int FromLocationId { get; set; }
        
        public bool? IsClosed { get; set; }
    }
}
