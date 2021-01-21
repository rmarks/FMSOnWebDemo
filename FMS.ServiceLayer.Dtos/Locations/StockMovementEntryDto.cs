using System;

namespace FMS.ServiceLayer.Dtos
{
    public class StockMovementEntryDto
    {
        public string DocNo { get; set; }
        public string DocTypeName { get; set; }
        public string DocPartyName { get; set; }
        public DateTime DocDate { get; set; }
        public int Quantity { get; set; }
    }
}
