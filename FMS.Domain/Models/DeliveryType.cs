using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FMS.Domain.Models
{
    public class DeliveryType
    {
        public int Id { get; set; }
        
        [Required, MaxLength(1)]
        public string Code { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; }
        
        public int InOut { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}
