using System;

namespace FMS.ServiceLayer.Dtos
{
    public class ReceiptListItemDto : IItemDto
    {
        public int ItemId { get; set; }
        public string DeliveryNo { get; set; }
        public string ToLocationName { get; set; }
        public string FromLocationName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string StatusName { get; set; }
    }
}
