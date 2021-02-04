using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductFilterDropdowns
    {
        public IDictionary<int, string> ProductStatuses { get; set; }
        public IDictionary<int, string> BusinessLines { get; set; }
        public IDictionary<int, string> ProductSourceTypes { get; set; }
        public IDictionary<int, string> ProductDestinationTypes { get; set; }
        public IDictionary<int, string> ProductMaterials { get; set; }
        public IDictionary<int, string> ProductTypes { get; set; }
        public IDictionary<int, string> ProductGroups { get; set; }
        public IDictionary<int, string> ProductBrands { get; set; }
        public IDictionary<int, string> ProductCollections { get; set; }
        public IDictionary<int, string> ProductDesigns { get; set; }
    }
}
