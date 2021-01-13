using System;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class DeliveryNoteDto
    {
        public int Id { get; set; }
        public string DeliveryNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ToLocationName { get; set; }
        public string FromLocationName { get; set; }
        public bool IsClosed { get; set; }
        public IList<DeliveryNoteLineDto> Lines { get; set; } = new List<DeliveryNoteLineDto>();
    }
}
