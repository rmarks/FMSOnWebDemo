﻿namespace FMS.ServiceLayer.Dtos
{
    public class ProductInStockDto
    {
        public int LocationId { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int FreeQuantity => StockQuantity - ReservedQuantity;
    }
}
