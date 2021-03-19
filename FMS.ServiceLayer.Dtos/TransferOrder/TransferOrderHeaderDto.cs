using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.ServiceLayer.Dtos
{
    public class TransferOrderHeaderDto
    {
        public int Id { get; set; }
        public int OrderTypeId { get; set; }
        
        [Required(ErrorMessage = "Kohustuslik väli")]
        [StringLength(10, ErrorMessage = "Liiga pikk (max 10)")]
        public string OrderNo { get; set; }

        [Required(ErrorMessage = "Kohustuslik väli")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Kohustuslik väli")]
        public DateTime? OrderDeliveryDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Kohustuslik väli")]
        public int LocationId { get; set; }
        
        public bool IsClosed { get; set; }
        public DateTime? CreatedOn { get; set; }

        public static TransferOrderHeaderDto CreateFrom(TransferOrderHeaderDto source)
        {
            return new TransferOrderHeaderDto
            {
                Id = source.Id,
                OrderTypeId = source.OrderTypeId,
                OrderNo = source.OrderNo,
                OrderDate = source.OrderDate,
                OrderDeliveryDate = source.OrderDeliveryDate,
                LocationId = source.LocationId,
                IsClosed = source.IsClosed,
                CreatedOn = source.CreatedOn
            };
        }
    }
}
