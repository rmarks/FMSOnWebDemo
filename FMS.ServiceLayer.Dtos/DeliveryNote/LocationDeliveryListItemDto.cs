using System;

namespace FMS.ServiceLayer.Dtos
{
    public class LocationDeliveryListItemDto
    {
        public int DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public string ToLocationName { get; set; }
        public string FromLocationName { get; set; }
        public DateTime DocumentDate { get; set; }
        public string StatusName { get; set; }
    }
}
