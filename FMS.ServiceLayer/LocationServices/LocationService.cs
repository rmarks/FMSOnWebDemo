using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly FMSContext _context;

        public LocationService(FMSContext context)
        {
            _context = context;
        }

        public string GetLocationName(int locationId)
        {
            return _context.Locations
                .AsNoTracking()
                .FirstOrDefault(l => l.Id == locationId).Name;
        }

        public PagedList<LocationListItemDto> GetWarehouses(LocationListOptions options)
        {
            return FilterPage(options, "VL");
        }

        #region helpers
        private PagedList<LocationListItemDto> FilterPage(LocationListOptions options, string locationTypeCode)
        {
            return _context.Locations
                .AsNoTracking()
                .Where(l => l.LocationType.Code == locationTypeCode)
                .OrderBy(l => l.Name)
                .Select(l => new LocationListItemDto
                {
                    LocationId = l.Id,
                    LocationName = l.Name,
                    TotalCount = l.Inventory.Where(i => i.StockQuantity != 0).Count(),
                    TotalStockQuantity = l.Inventory.Sum(i => i.StockQuantity),
                    TotalReservedQuantity = l.Inventory.Sum(i => i.ReservedQuantity)
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
        #endregion
    }
}
