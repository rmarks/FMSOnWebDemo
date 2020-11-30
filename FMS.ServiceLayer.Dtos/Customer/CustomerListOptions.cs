namespace FMS.ServiceLayer.Dtos
{
    public class CustomerListOptions : PagedArgsBase
    {
        public string SearchString { get; set; } = string.Empty;
    }
}
