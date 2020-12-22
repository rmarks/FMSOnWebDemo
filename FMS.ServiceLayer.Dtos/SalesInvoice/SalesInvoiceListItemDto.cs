using System;

namespace FMS.ServiceLayer.Dtos
{
    public class SalesInvoiceListItemDto
    {
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public string ConsigneeName { get; set; }
    }
}
