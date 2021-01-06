using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class DeliveryNote
    {
        public int Id { get; set; }
        
        [Required, MaxLength(10)]
        public string DeliveryNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        
        public int? FromLocationId { get; set; }
        [ForeignKey(nameof(FromLocationId))]
        public Location Location { get; set; }

        public int? ToLocationId { get; set; }
        [ForeignKey(nameof(ToLocationId))]
        public Location ToLocation { get; set; }

        public bool IsClosed { get; set; }
        public DateTime? CreatedOn { get; set; }

        //public int DeliveryTypeId { get; set; }
        public int DeliveryDomainId { get; set; }

        public IList<DeliveryNoteLine> DeliveryNoteLines { get; set; }


        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }

        [MaxLength(8)]
        public string FMS_doknr { get; set; }

        [MaxLength(6)]
        public string FMS_skood { get; set; }
    }
}
