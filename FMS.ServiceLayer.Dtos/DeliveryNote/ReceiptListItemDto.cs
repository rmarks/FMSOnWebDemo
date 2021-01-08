using System;

namespace FMS.ServiceLayer.Dtos
{
    public class ReceiptListItemDto
    {
        public int DeliveryNoteId { get; set; }
        public string DeliveryNo { get; set; }
        public string ReceiverName { get; set; }
        public string ShipperName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string StatusName { get; set; }
    }
}
