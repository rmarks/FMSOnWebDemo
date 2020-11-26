using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductDesign
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public int ProductCollectionId { get; set; }
        public ProductCollection ProductCollection { get; set; }
    }
}
