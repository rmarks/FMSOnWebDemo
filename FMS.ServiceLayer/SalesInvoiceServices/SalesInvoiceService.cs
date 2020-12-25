using FMS.Dal;
using FMS.Domain.Models;
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
            return await _context.SalesInvoices
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SalesInvoiceDto
                {
                    SalesInvoiceId = s.Id,
                    InvoiceNo = s.InvoiceNo,
                    InvoiceDate = s.InvoiceDate,
                    CustomerId = s.CustomerId,
                    CustomerName = s.Customer.Name,
                    CustomerAddress = $"{s.BillingAddress.Country.Name}\n{s.BillingAddress.City}, {s.BillingAddress.PostCode}\n{s.BillingAddress.Address}",
                    ConsigneeName = $"{(s.ShippingAddress.IsBilling ? s.Customer.Name : s.ShippingAddress.Description)}",
                    ConsigneeAddress = $"{s.ShippingAddress.Country.Name}\n{s.ShippingAddress.City}, {s.ShippingAddress.PostCode}\n{s.ShippingAddress.Address}"
                })
                .FirstOrDefaultAsync();
        }
    }
}
