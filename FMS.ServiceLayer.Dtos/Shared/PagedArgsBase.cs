namespace FMS.ServiceLayer.Dtos
{
    public abstract class PagedArgsBase
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
