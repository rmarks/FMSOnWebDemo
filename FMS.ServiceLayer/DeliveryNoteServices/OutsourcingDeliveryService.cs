using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class OutsourcingDeliveryService : IOutsourcingDeliveryService
    {
        private readonly FMSContext _context;

        public OutsourcingDeliveryService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<DeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options)
        {
            var queryable = _context.Documents
                .AsNoTracking();

            queryable = queryable.Where(d => d.DocumentType.Code == "AT");

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
                    FromLocationName = "Allhankijad",
                    DeliveryDate = d.DocumentDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }

        public PagedList<DeliveryListItemDto> ShipmentFilterPage(DeliveryListOptions options)
        {
            var queryable = _context.Documents
                .AsNoTracking();

            queryable = queryable.Where(d => d.DocumentType.Code == "AG");

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
                    ToLocationName = "Allhankijad",
                    FromLocationName = d.Location.Name,
                    DeliveryDate = d.DocumentDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
