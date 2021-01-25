using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class LocationDeliveryService : ILocationDeliveryService
    {
        private readonly FMSContext _context;

        public LocationDeliveryService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<LocationDeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options)
        {
            var queryable = _context.Documents
                .AsNoTracking();

            queryable = queryable
                .Where(d => d.DocumentType.Code == options.DocumentTypeCode && d.Location.LocationType.Code == options.ToLocationTypeCode);

            return queryable
                .OrderByDescending(d => d.DocumentDate)
                .Select(d => new LocationDeliveryListItemDto
                {
                    DocumentId = d.Id,
                    DocumentNo = d.DocumentNo,
                    ToLocationName = d.Location.Name,
                    FromLocationName = d.ToFromLocation.Name,
                    DocumentDate = d.DocumentDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
