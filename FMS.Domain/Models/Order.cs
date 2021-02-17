using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderTypeId { get; set; }
        public OrderType OrderType { get; set; }

        [Required, MaxLength(10)]
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }

        [MaxLength(20)]
        public string ClientOrderNo { get; set; }
        public DateTime? ClientOrderDate { get; set; }
        public DateTime? ClientOrderDeliveryDate { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? BillingAddressId { get; set; }
        [ForeignKey(nameof(BillingAddressId))]
        public CustomerAddress BillingAddress { get; set; }

        public int? ShippingAddressId { get; set; }
        [ForeignKey(nameof(ShippingAddressId))]
        public CustomerAddress ShippingAddress { get; set; }

        public int LocationId { get; set; }
        public int PaymentDays { get; set; }
        public string DeliveryTermText { get; set; }
        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public IList<OrderLine> SalesOrderLines { get; set; } = new List<OrderLine>();
    }
}
