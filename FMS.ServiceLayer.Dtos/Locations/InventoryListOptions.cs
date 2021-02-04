namespace FMS.ServiceLayer.Dtos
{
    public class InventoryListOptions : PagedArgsBase
    {
        public int LocationId { get; set; }
        public bool IsInStore { get; set; }

        public ProductFilterOptions ProductFilterOptions { get; set; } = new ProductFilterOptions();
    }
}
