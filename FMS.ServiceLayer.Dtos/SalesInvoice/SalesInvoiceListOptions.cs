namespace FMS.ServiceLayer.Dtos
{
    public class SalesInvoiceListOptions : PagedArgsBase
    {
        public string SearchByCustomerName { get; set; }
        public string SearchByConsigneeName { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
    }

    public enum InvoiceStatus { All, Open, Closed}
}
