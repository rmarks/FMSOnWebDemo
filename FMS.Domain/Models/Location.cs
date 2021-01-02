using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        public DateTime? CreatedOn { get; set; }

        public int LocationTypeId { get; set; }

        public IList<Inventory> Inventory { get; set; }


        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_lkood { get; set; }

        [MaxLength(2)]
        public string FMS_skood { get; set; }
    }
}
