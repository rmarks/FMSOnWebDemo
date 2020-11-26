using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductSourceType
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [Required, MaxLength(1)]
        public string FMS_akat { get; set; }
    }
}
