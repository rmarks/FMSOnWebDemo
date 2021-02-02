using System;

namespace FMS.Domain.Models
{
    public class DocumentLine
    {
        public int Id { get; set; }
        
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }


        //--- legacy system fields ---
        public int FMS_liikumid { get; set; }
    }
}
