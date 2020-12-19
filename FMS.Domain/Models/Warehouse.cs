using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public DateTime CreatedOn { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_lkood { get; set; }
    }
}
