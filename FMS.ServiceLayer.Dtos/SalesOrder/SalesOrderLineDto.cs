namespace FMS.ServiceLayer.Dtos
{
    public class SalesOrderLineDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int LineDiscountPercent { get; set; }
        public int OrderedQuantity { get; set; }
        public int InvoicedQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int MissingQuantity => OrderedQuantity - InvoicedQuantity - ReservedQuantity;
    }
}
