using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.ServiceLayer.Dtos
{
    public class ProductStockMovementsDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductBaseCode { get; set; }
        public string ProductName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ProductCreatedOn { get; set; }

        public IList<StockMovementEntryDto> Movements { get; set; }
    }
}
