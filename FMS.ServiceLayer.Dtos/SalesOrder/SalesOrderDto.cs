using System;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class SalesOrderDto
    {
        public int OrderId { get; set; }

        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }

        public string DeliveryTermName { get; set; }
        public int PaymentDays { get; set; }
        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }

        public List<SalesOrderLineDto> SalesOrderLines { get; set; } = new List<SalesOrderLineDto>();
    }
}
