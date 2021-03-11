using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.TransferOrderServices
{
    public class TransferOrderService : ITransferOrderService
    {
        private readonly FMSContext _context;

        public TransferOrderService(FMSContext context)
        {
            _context = context;
        }

        public async Task<TransferOrderDto> GetOrder(int id)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new TransferOrderDto
                {
                    OrderId = o.Id,
                    OrderNo = o.OrderNo,
                    OrderDate = o.OrderDate,
                    DeliveryDate = o.OrderDeliveryDate,
                    LocationId = o.LocationId,
                    IsClosed = o.IsClosed,
                    OrderLines = o.OrderLines.Select(l => new TransferOrderLineDto
                    {
                        Id = l.Id,
                        OrderId = l.OrderId,
                        LocationName = l.Location.Name,
                        ProductCode = l.Product.Code,
                        ProductName = l.Product.Name,
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
