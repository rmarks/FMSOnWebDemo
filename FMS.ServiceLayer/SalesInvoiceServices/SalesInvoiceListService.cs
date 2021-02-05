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
            var queryable = _context.Documents
                .AsNoTracking()
                .Where(d => d.DocumentType.Code == options.DocumentTypeCode);

            if (!string.IsNullOrWhiteSpace(options.CustomerNameSearchString))
            {
                queryable = queryable.Where(d => d.Customer.Name.Contains(options.CustomerNameSearchString));
            }

            if (!string.IsNullOrWhiteSpace(options.ConsigneeNameSearchString))
            {
                //queryable = queryable.Where(d => d.ShippingAddress.Description.Contains(options.ConsigneeNameSearchString));
                queryable = queryable.Where(d => d.ShippingAddress.IsBilling 
                    ? d.Customer.Name.Contains(options.ConsigneeNameSearchString)
                    : d.ShippingAddress.Description.Contains(options.ConsigneeNameSearchString));
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(d => d.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(d => d.DocumentNo)
                .Select(d => new SalesInvoiceListItemDto
                {
                    InvoiceId = d.Id,
                    InvoiceNo = d.DocumentNo,
                    InvoiceDate = d.DocumentDate,
                    CustomerName = d.Customer.Name,
                    ConsigneeName = d.ShippingAddress.IsBilling ? d.Customer.Name : d.ShippingAddress.Description,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
