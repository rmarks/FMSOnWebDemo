using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class ReceiptDropdowns
    {
        public IDictionary<string, int> ToLocations { get; set; }
        public IDictionary<string, int> FromLocations { get; set; }
    }
}
