using System;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class TransferOrderDto
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int LocationId { get; set; }
        public bool IsClosed { get; set; }

        public List<TransferOrderLineDto> OrderLines { get; set; } = new List<TransferOrderLineDto>();
    }
}
