using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductBaseInfoDto
    {
        public int ProductBaseId { get; set; }
        public string ProductBaseCode { get; set; }
        public IList<WarehouseInventoryDto> Warehouses { get; set; }
    }
}
