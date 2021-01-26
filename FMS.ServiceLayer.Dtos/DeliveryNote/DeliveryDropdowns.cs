using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class DeliveryDropdowns
    {
        public IDictionary<string, int> ToLocationTypes { get; set; }
        public IDictionary<string, int> ToLocations { get; set; }

        public IDictionary<string, int> FromLocationTypes { get; set; }
        public IDictionary<string, int> FromLocations { get; set; }
    }
}
