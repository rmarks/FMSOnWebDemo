using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class WarehouseInventoryDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public IList<ProductInStockDto> Products { get; set; }
    }
}
