using System.Collections.Generic;

namespace FMS.Domain.Models
{
    public class ProductBaseProductVariantType
    {
        public int ProductBaseId { get; set; }

        public int ProductVariantTypeId { get; set; }
        public ProductVariantType ProductVariantType { get; set; }

        public IList<ProductBaseProductVariant> ProductBaseProductVariants { get; set; }
    }
}
