namespace FMS.Domain.Models
{
    public class ProductProductVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductBaseProductVariantId { get; set; }
        public ProductBaseProductVariant ProductBaseProductVariant { get; set; }
    }
}
