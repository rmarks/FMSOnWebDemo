using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class CustomerContact
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string Job { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
