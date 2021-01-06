using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class DeliveryNoteLine
    {
        public int Id { get; set; }

        public int DeliveryNoteId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DeliveredQuantity { get; set; }

        public DateTime? CreatedOn { get; set; }


        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }

        [MaxLength(8)]
        public string FMS_doknr { get; set; }
    }
}
