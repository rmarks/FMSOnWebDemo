using System;

namespace FMS.Domain.Models
{
    public class DeliveryNoteLine
    {
        public int Id { get; set; }

        public int DeliveryNoteId { get; set; }

        public int ProductId { get; set; }
        public int DeliveredQuantity { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
