using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.SalesOrderServices
{
    public class SalesOrderListService : ISalesOrderListService
    {
        private readonly FMSContext _context;

        public SalesOrderListService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<SalesOrderListItemDto> FilterPage(SalesOrderListOptions options)
        {
            var queryable = _context.SalesOrders
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(options.CustomerNameSearchString))
            {
                queryable = queryable.Where(s => s.Customer.Name.Contains(options.CustomerNameSearchString));
            }

            if (!string.IsNullOrWhiteSpace(options.ConsigneeNameSearchString))
            {
                queryable = queryable.Where(s => s.ShippingAddress.IsBilling
                    ? s.Customer.Name.Contains(options.ConsigneeNameSearchString)
                    : s.ShippingAddress.ConsigneeName.Contains(options.ConsigneeNameSearchString));
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(s => s.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(s => s.OrderNo)
                .Select(s => new SalesOrderListItemDto
                {
                    OrderId = s.Id,
                    OrderNo = s.OrderNo,
                    OrderDate = s.OrderDate,
                    DeliveryDate = s.OrderDeliveryDate,
                    CustomerName = s.Customer.Name,
                    ConsigneeName = s.ShippingAddress.IsBilling ? s.Customer.Name : s.ShippingAddress.ConsigneeName,
                    StatusName = s.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
