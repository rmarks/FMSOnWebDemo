using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class LocationType
    {
        public int Id { get; set; }
        
        [Required, MaxLength(2)]
        public string Code { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}
