namespace FMS.ServiceLayer.Dtos
{
    public class SalesInvoiceListOptions : PagedArgsBase
    {
        public string CustomerNameSearchString { get; set; }
        public string ConsigneeNameSearchString { get; set; }
        public bool? IsClosed { get; set; }
        public string DocumentTypeCode { get; set; }
    }
}
