using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }


        //legacy system fields
        public string FMS_rkood { get; set; }
    }
}
