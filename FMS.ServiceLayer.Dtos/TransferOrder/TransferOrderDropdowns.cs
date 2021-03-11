using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class TransferOrderDropdowns
    {
        public IDictionary<string, int> CommissionLocations { get; set; } = new Dictionary<string, int>();
        public IDictionary<string, int> WarehouseLocations { get; set; } = new Dictionary<string, int>();
    }
}
