namespace FMS.ServiceLayer.Dtos
{
    public class DeliveryListOptions : PagedArgsBase
    {
        public string DocumentTypeCode { get; set; }

        public string ToLocationTypeCode { get; set; }
        public int ToLocationId { get; set; }
        
        public int FromLocationId { get; set; }
        
        public bool? IsClosed { get; set; }
    }
}
