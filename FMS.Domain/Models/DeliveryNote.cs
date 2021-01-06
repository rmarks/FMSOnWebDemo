using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class DeliveryNote
    {
        public int Id { get; set; }
        
        [Required, MaxLength(10)]
        public string DeliveryNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public bool IsClosed { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int DeliveryTypeId { get; set; }
        public int DeliveryDomainId { get; set; }
    }
}
