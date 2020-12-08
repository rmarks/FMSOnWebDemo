using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class CustomerDropdowns
    {
        public IDictionary<string, int> Countries { get; set; }
        public IDictionary<string, int> PaymentTerms { get; set; }
    }
}
