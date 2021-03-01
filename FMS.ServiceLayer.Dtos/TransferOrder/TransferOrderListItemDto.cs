using System;

namespace FMS.ServiceLayer.Dtos
{
    public class TransferOrderListItemDto
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string LocationName { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string StatusName { get; set; }
    }
}
