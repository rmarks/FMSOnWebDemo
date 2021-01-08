namespace FMS.ServiceLayer.Dtos
{
    public class ReceiptListOptions : PagedArgsBase
    {
        public int ToLocationId { get; set; }
        public bool? IsClosed { get; set; }
    }
}
