namespace FMS.ServiceLayer.Dtos
{
    public class TransferOrderOptions : PagedArgsBase
    {
        public int LocationId { get; set; }
        public bool? IsClosed { get; set; }

        public bool IsReturnToList { get; set; }
    }
}
