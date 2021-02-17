using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.SalesOrderServices
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly FMSContext _context;

        public SalesOrderService(FMSContext context)
        {
            _context = context;
        }

        public async Task<SalesOrderDto> GetOrder(int id)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SalesOrderDto
                {
                    OrderId = s.Id,
                    OrderNo = s.OrderNo,
                    OrderDate = s.OrderDate,
                    DeliveryDate = s.OrderDeliveryDate,
                    CustomerName = s.Customer.Name,
                    CustomerAddress = $"{s.BillingAddress.Country.Name}\n{s.BillingAddress.City}, {s.BillingAddress.PostCode}\n{s.BillingAddress.Address}",
                    ConsigneeName = $"{(s.ShippingAddress.IsBilling ? s.Customer.Name : s.ShippingAddress.ConsigneeName)}",
                    ConsigneeAddress = $"{s.ShippingAddress.Country.Name}\n{s.ShippingAddress.City}, {s.ShippingAddress.PostCode}\n{s.ShippingAddress.Address}",
                    DeliveryTermName = s.DeliveryTermText,
                    PaymentDays = s.PaymentDays,
                    FixedDiscountPercent = s.FixedDiscountPercent,
                    VATPercent = s.VATPercent,
                    IsClosed = s.IsClosed,
                    SalesOrderLines = s.SalesOrderLines.Select(l => new SalesOrderLineDto
                    {
                        Id = l.Id,
                        ProductCode = l.Product.Code,
                        ProductName = l.Product.Name,
                        UnitPrice = l.UnitPrice,
                        LineDiscountPercent = l.LineDiscountPercent,
                        OrderedQuantity = l.OrderedQuantity,
                        InvoicedQuantity = l.InvoicedQuantity,
                        ReservedQuantity = l.ReservedQuantity
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
