using FMS.Domain.Models;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductDropdowns
    {
        public IList<ProductStatus> ProductStatuses { get; set; }
        public IList<BusinessLine> BusinessLines { get; set; }
        public IList<ProductSourceType> ProductSourceTypes { get; set; }
        public IList<ProductDestinationType> ProductDestinationTypes { get; set; }
        public IList<ProductMaterial> ProductMaterials { get; set; }
        public IList<ProductType> ProductTypes { get; set; }
        public IList<ProductGroup> ProductGroups { get; set; }
        public IList<ProductBrand> ProductBrands { get; set; }
        public IList<ProductCollection> ProductCollections { get; set; }
        public IList<ProductDesign> ProductDesigns { get; set; }

        public IList<Location> Locations { get; set; }
    }
}
