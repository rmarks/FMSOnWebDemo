using System;

namespace FMS.ServiceLayer.Dtos
{
    public class SalesOrderListItemDto
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string CustomerName { get; set; }
        public string ConsigneeName { get; set; }
        public string StatusName { get; set; }
    }
}
