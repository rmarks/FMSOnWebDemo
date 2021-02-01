using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class PurchaseDeliveryService : IPurchaseDeliveryService
    {
        private readonly FMSContext _context;

        public PurchaseDeliveryService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<DeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options)
        {
            var queryable = _context.Documents
                .AsNoTracking();

            queryable = queryable.Where(d => d.DocumentType.Code == "OT");

            if (options.ToLocationId != 0)
            {
                queryable = queryable.Where(d => d.LocationId == options.ToLocationId);
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(d => d.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(d => d.DocumentDate)
                .Select(d => new DeliveryListItemDto
                {
                    DeliveryNoteId = d.Id,
                    DeliveryNo = d.DocumentNo,
                    ToLocationName = d.Location.Name,
                    FromLocationName = "Muud hankijad",
                    DeliveryDate = d.DocumentDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }

        public PagedList<DeliveryListItemDto> ShipmentFilterPage(DeliveryListOptions options)
        {
            var queryable = _context.Documents
                .AsNoTracking();

            queryable = queryable.Where(d => d.DocumentType.Code == "OG");

            if (options.FromLocationId != 0)
            {
                queryable = queryable.Where(d => d.LocationId == options.FromLocationId);
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(d => d.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(d => d.DocumentDate)
                .Select(d => new DeliveryListItemDto
                {
                    DeliveryNoteId = d.Id,
                    DeliveryNo = d.DocumentNo,
                    ToLocationName = "Muud hankijad",
                    FromLocationName = d.Location.Name,
                    DeliveryDate = d.DocumentDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
