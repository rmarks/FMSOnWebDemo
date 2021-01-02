using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class PaymentTerm
    {
        public int Id { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; }

        public int PaymentDays { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
