using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductVariantType
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public bool HasStandardVariants { get; set; }
    }
}
