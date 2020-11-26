using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class StandardProductVariant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string Code { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int ProductVariantTypeId { get; set; }
        public ProductVariantType ProductVariantType { get; set; }
    }
}
