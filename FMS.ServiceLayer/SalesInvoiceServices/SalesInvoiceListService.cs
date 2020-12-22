using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.SalesInvoiceServices
{
    public class SalesInvoiceListService : ISalesInvoiceListService
    {
        private readonly FMSContext _context;

        public SalesInvoiceListService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<SalesInvoiceListItemDto> FilterPage(SalesInvoiceListOptions options)
        {
            var queryable = _context.SalesInvoices
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(options.SearchByCustomerName))
            {
                queryable = queryable.Where(c => c.Customer.Name.ToLower().Contains(options.SearchByCustomerName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(options.SearchByConsigneeName))
            {
                queryable = queryable.Where(c => c.ShippingAddress.Description.ToLower().Contains(options.SearchByConsigneeName.ToLower()));
            }

            if (options.InvoiceStatus == InvoiceStatus.Open)
            {
                queryable = queryable.Where(s => !s.IsClosed);
            }
            else if (options.InvoiceStatus == InvoiceStatus.Closed)
            {
                queryable = queryable.Where(s => s.IsClosed);
            }

            return queryable
                .OrderByDescending(s => s.InvoiceNo)
                .Select(s => new SalesInvoiceListItemDto
                {
                    InvoiceId = s.Id,
                    InvoiceNo = s.InvoiceNo,
                    InvoiceDate = s.InvoiceDate,
                    CustomerName = s.Customer.Name,
                    ConsigneeName = s.ShippingAddress.IsBilling ? s.Customer.Name : s.ShippingAddress.Description
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
