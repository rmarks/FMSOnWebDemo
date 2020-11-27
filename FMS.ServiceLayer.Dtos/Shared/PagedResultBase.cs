namespace FMS.ServiceLayer.Dtos
{
    public abstract class PagedResultBase : PagedArgsBase
    {
        public int PageCount { get; set; }
        public int ItemsCount { get; set; }
    }
}
