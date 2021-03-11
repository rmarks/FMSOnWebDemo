namespace FMS.ServiceLayer.Dtos
{
    public class TransferOrderLineDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string LocationName { get; set; }
        
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        
        public int OrderedQuantity { get; set; }
        public int InvoicedQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int MissingQuantity => OrderedQuantity - InvoicedQuantity - ReservedQuantity;
    }
}
