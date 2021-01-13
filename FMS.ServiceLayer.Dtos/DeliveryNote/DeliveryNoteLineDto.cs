namespace FMS.ServiceLayer.Dtos
{
    public class DeliveryNoteLineDto
    {
        public int Id { get; set; }
        public int DeliveryNoteId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int DeliveredQuantity { get; set; }
    }
}
