using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [MaxLength(1)]
        public string FMS_aliik { get; set; }
    }
}
