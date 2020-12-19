namespace FMS.ServiceLayer.Dtos
{
    public class ProductListOptions : PagedArgsBase
    {
        public int ProductStatusId { get; set; }
        public int BusinessLineId { get; set; }
        public int ProductSourceTypeId { get; set; }
        public int ProductDestinationTypeId { get; set; }
        public int ProductMaterialId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductGroupId { get; set; }
        public int ProductBrandId { get; set; }
        public int ProductCollectionId { get; set; }
        public int ProductDesignId { get; set; }

        public int WarehouseId { get; set; }
        public Stock Stock { get; set; }
    }

    public enum Stock { AllInStock, OnlyInStock, NotInStock }
}
