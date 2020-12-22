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
            queryable = queryable.Where(s => !s.IsClosed);

            return queryable
                .OrderByDescending(s => s.OrderNo)
                .Select(s => new SalesOrderListItemDto
                {
                    OrderId = s.Id,
                    OrderNo = s.OrderNo,
                    OrderDate = s.OrderDate,
                    DeliveryDate = s.OrderDeliveryDate,
                    CustomerName = s.Customer.Name,
                    ConsigneeName = s.ShippingAddress.IsBilling ? s.Customer.Name : s.ShippingAddress.Description
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
