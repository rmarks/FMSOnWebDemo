using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductInfo
    {
        public string ProductCode { get; set; }
        public IList<ProductInStock> Inventory { get; set; }
    }
}
