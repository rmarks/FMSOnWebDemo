using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class PurchaseReceiptService : IPurchaseReceiptService
    {
        private readonly FMSContext _context;

        public PurchaseReceiptService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<ReceiptListItemDto> FilterPage(ReceiptListOptions options)
        {
            var queryable = _context.DeliveryNotes
                .AsNoTracking();

            queryable = queryable.Where(d => d.DeliveryDomain.Code == "O" && d.ToLocation.LocationType.Code == "VL");

            if (options.ToLocationId != 0)
            {
                queryable = queryable.Where(d => d.ToLocationId == options.ToLocationId);
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
                    FromLocationName = "Muud hankijad",
                    DeliveryDate = d.DeliveryDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
