using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.ServiceLayer.Dtos
{
    public class SalesInvoiceDto
    {
        public int SalesInvoiceId { get; set; }

        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }

        public string DeliveryTermName { get; set; }
        public string PaymentTermName { get; set; }
        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }
    }
}
