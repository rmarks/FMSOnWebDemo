using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class PagedList<T> : PagedResultBase where T : class
    {
        public IList<T> List { get; set; }
    }
}
