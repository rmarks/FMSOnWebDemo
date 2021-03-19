using FMS.Dal;
using FMS.Domain.Models;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<TransferOrderLineDto>> GetOrderLinesAsync(int orderId)
        {
            return await _context.OrderLines
                .AsNoTracking()
                .Where(l => l.OrderId == orderId)
                .Select(l => new TransferOrderLineDto
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
                .ToListAsync();
        }

        public async Task<TransferOrderHeaderDto> CreateOrderHeaderAsync(TransferOrderHeaderDto dto)
        {
            dto.OrderTypeId = _context.OrderTypes.AsNoTracking().FirstOrDefault(o => o.Code == "LT").Id;
            dto.CreatedOn = DateTime.Now;

            Order order = new Order(); 
            var entry = await _context.AddAsync(order);
            entry.CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            dto.Id = order.Id;
            return dto;
        }

        public async Task<TransferOrderHeaderDto> ReadOrderHeaderAsync(int id)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new TransferOrderHeaderDto
                {
                    Id = o.Id,
                    OrderTypeId = o.OrderTypeId,
                    OrderNo = o.OrderNo,
                    OrderDate = o.OrderDate,
                    OrderDeliveryDate = o.OrderDeliveryDate,
                    LocationId = o.LocationId,
                    IsClosed = o.IsClosed,
                    CreatedOn = o.CreatedOn
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateOrderHeaderAsync(TransferOrderHeaderDto dto)
        {
            var order = await _context.Orders.FindAsync(dto.Id);
            _context.Entry(order).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            if (id == 0) return false;

            var order = await _context.Orders
                .Include(o => o.OrderLines)
                .FirstOrDefaultAsync(o => o.Id == id);

            _context.Orders.Remove(order);
            int savedCount = await _context.SaveChangesAsync();
            
            return savedCount > 0;
        }
    }
}
