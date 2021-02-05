namespace FMS.ServiceLayer.Dtos
{
    public class SalesOrderListOptions : PagedArgsBase
    {
        public string CustomerNameSearchString { get; set; }
        public string ConsigneeNameSearchString { get; set; }
        public bool? IsClosed { get; set; }
    }
}
