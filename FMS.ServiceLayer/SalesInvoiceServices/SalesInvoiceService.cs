﻿using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.SalesInvoiceServices
{
    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly FMSContext _context;

        public SalesInvoiceService(FMSContext context)
        {
            _context = context;
        }

        public async Task<SalesInvoiceDto> GetInvoice(int id)
        {
            return await _context.Documents
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new SalesInvoiceDto
                {
                    InvoiceId = d.Id,
                    InvoiceNo = d.DocumentNo,
                    InvoiceDate = d.DocumentDate,
                    CustomerName = d.Customer.Name,
                    CustomerAddress = $"{d.BillingAddress.Country.Name}\n{d.BillingAddress.City}, {d.BillingAddress.PostCode}\n{d.BillingAddress.Address}",
                    ConsigneeName = $"{(d.ShippingAddress.IsBilling ? d.Customer.Name : d.ShippingAddress.ConsigneeName)}",
                    ConsigneeAddress = $"{d.ShippingAddress.Country.Name}\n{d.ShippingAddress.City}, {d.ShippingAddress.PostCode}\n{d.ShippingAddress.Address}",
                    DeliveryTermName = d.DeliveryTermName,
                    PaymentDays = d.PaymentDays,
                    FixedDiscountPercent = d.FixedDiscountPercent,
                    VATPercent = d.VATPercent,
                    IsClosed = d.IsClosed,
                    SalesInvoiceLines = d.DocumentLines.Select(l => new SalesInvoiceLineDto
                    {
                        Id = l.Id,
                        ProductCode = l.Product.Code,
                        ProductName = l.Product.Name,
                        UnitPrice = l.UnitPrice,
                        LineDiscountPercent = l.LineDiscountPercent,
                        Quantity = l.Quantity
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
