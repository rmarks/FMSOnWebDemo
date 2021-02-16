namespace FMS.ServiceLayer.Dtos
{
    public class SalesInvoiceLineDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }
        public int Quantity { get; set; }
    }
}
