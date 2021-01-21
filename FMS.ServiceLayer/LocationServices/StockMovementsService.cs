using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMS.ServiceLayer.LocationServices
{
    public class StockMovementsService : IStockMovementsService
    {
        private readonly FMSContext _context;

        public StockMovementsService(FMSContext context)
        {
            _context = context;
        }

        public ProductStockMovementsDto GetProductStockMovements(int productId, int locationId)
        {
            var dto = _context.Products
                .AsNoTracking()
                .Where(p => p.Id == productId)
                .Select(p => new ProductStockMovementsDto
                {
                    ProductId = p.Id,
                    ProductCode = p.Code,
                    ProductBaseCode = p.ProductBase.Code
                })
                .FirstOrDefault();

            List<StockMovementEntryDto> invoices = _context.SalesInvoiceLines
                .AsNoTracking()
                .Where(s => s.ProductId == productId)
                .OrderByDescending(s => s.SalesInvoice.InvoiceDate)
                .Select(s => new StockMovementEntryDto
                {
                    DocNo = s.SalesInvoice.InvoiceNo,
                    DocTypeName = "Müügiarve",
                    DocPartyName = s.SalesInvoice.Customer.Name,
                    DocDate = s.SalesInvoice.InvoiceDate,
                    Quantity = -s.InvoicedQuantity
                })
                .ToList();

            List<StockMovementEntryDto> notes = _context.DeliveryNoteLines
                .AsNoTracking()
                .Where(d => d.ProductId == productId)
                .OrderByDescending(d => d.DeliveryNote.DeliveryDate)
                .Select(d => new StockMovementEntryDto
                {
                    DocNo = d.DeliveryNote.DeliveryNo,
                    DocTypeName = d.DeliveryNote.FromLocationId == locationId ? "Lähetus" : "Tarne",
                    DocPartyName = d.DeliveryNote.DeliveryDomain.Name,
                    DocDate = d.DeliveryNote.DeliveryDate,
                    Quantity = d.DeliveryNote.FromLocationId == locationId ? -d.DeliveredQuantity : d.DeliveredQuantity
                })
                .ToList();

            invoices.AddRange(notes);

            dto.Movements = invoices
                .OrderByDescending(i => i.DocDate)
                .Take(10)
                .ToList();

            return dto;
        }
    }
}
