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
                    ProductBaseCode = p.ProductBase.Code,
                    ProductName = p.Name
                })
                .FirstOrDefault();

            //List<StockMovementEntryDto> invoices = _context.SalesInvoiceLines
            //    .AsNoTracking()
            //    .Where(s => s.ProductId == productId)
            //    .OrderByDescending(s => s.SalesInvoice.InvoiceDate)
            //    .Select(s => new StockMovementEntryDto
            //    {
            //        DocNo = s.SalesInvoice.InvoiceNo,
            //        DocTypeName = "Müügiarve",
            //        DocPartyName = s.SalesInvoice.Customer.Name,
            //        DocDate = s.SalesInvoice.InvoiceDate,
            //        Quantity = -s.InvoicedQuantity
            //    })
            //    .ToList();

            List<StockMovementEntryDto> notes = _context.DocumentLines
                .AsNoTracking()
                .Where(d => d.ProductId == productId)
                .OrderByDescending(d => d.Document.DocumentDate)
                .Select(d => new StockMovementEntryDto
                {
                    DocNo = d.Document.DocumentNo,
                    DocTypeName = d.Document.DocumentType.Name,
                    DocPartyName = d.Document.ToFromLocation.Name ?? d.Document.Customer.Name,
                    DocDate = d.Document.DocumentDate,
                    Quantity = d.Document.DocumentType.IOL * d.Quantity
                })
                .Take(20)
                .ToList();

            //invoices.AddRange(notes);

            //dto.Movements = invoices
            //.OrderByDescending(i => i.DocDate)
            //.Take(10)
            //.ToList();

            dto.Movements = notes;

            return dto;
        }
    }
}
