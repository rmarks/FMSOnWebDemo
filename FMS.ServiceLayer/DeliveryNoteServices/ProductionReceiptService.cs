using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class ProductionReceiptService : IProductionReceiptService
    {
        private readonly FMSContext _context;

        public ProductionReceiptService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<ReceiptListItemDto> FilterPage(ReceiptListOptions options)
        {
            var queryable = _context.DeliveryNotes
                .AsNoTracking();

            queryable = queryable.Where(d => d.ToLocation.LocationType.Code == "VL" && d.FromLocation.LocationType.Code == "TO");

            if (options.ToLocationId != 0)
            {
                queryable = queryable.Where(d => d.ToLocationId == options.ToLocationId);
            }

            if (options.FromLocationId != 0)
            {
                queryable = queryable.Where(d => d.FromLocationId == options.FromLocationId);
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(d => d.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(d => d.DeliveryDate)
                .Select(d => new ReceiptListItemDto
                {
                    DeliveryNoteId = d.Id,
                    DeliveryNo = d.DeliveryNo,
                    ToLocationName = d.ToLocation.Name,
                    FromLocationName = d.FromLocation.Name,
                    DeliveryDate = d.DeliveryDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
