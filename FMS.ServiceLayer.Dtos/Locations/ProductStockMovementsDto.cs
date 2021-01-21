using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductStockMovementsDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductBaseCode { get; set; }

        public IList<StockMovementEntryDto> Movements { get; set; }
    }
}
