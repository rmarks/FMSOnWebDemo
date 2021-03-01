using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.TransferOrderServices
{
    public class TransferOrderListService : ITransferOrderListService
    {
        private readonly FMSContext _context;

        public TransferOrderListService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<TransferOrderListItemDto> GetPage(TransferOrderOptions options)
        {
            var queryable = _context.Orders
                .AsNoTracking()
                .Where(o => o.OrderType.Code == "LT");

            if (options.LocationId != 0)
            {
                queryable = queryable.Where(o => o.LocationId == options.LocationId);
            }
            else
            {
                queryable = queryable.Where(o => o.Location.LocationType.Code == "KL");
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(d => d.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new TransferOrderListItemDto
                {
                    OrderId = o.Id,
                    OrderNo = o.OrderNo,
                    OrderDate = o.OrderDate,
                    LocationName = o.Location.Name,
                    DeliveryDate = o.OrderDeliveryDate,
                    StatusName = o.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
