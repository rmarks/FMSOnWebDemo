using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Code { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public int ProductBaseId { get; set; }
        public ProductBase ProductBase { get; set; }

        public IList<Inventory> Inventory { get; set; }

        //--- legacy system fields ---
        [MaxLength(12)]
        public string FMS_tkood { get; set; }
        [MaxLength(3)]
        public string FMS_suurus { get; set; }
    }
}
