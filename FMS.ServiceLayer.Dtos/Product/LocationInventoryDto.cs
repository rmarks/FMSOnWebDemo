using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class LocationInventoryDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public IList<ProductInStockDto> Products { get; set; }
    }
}
