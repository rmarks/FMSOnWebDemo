using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.LocationServices
{
    public class InventoryService : IInventoryService
    {
        private readonly FMSContext _context;

        public InventoryService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<InventoryListItemDto> FilterPage(InventoryListOptions options)
        {
            var queryable = _context.Inventory
                .AsNoTracking()
                .Where(i => i.LocationId == options.LocationId);

            if (options.IsInStore)
            {
                queryable = queryable.Where(i => i.StockQuantity > 0);
            }

            return queryable
                .OrderBy(i => i.Product.Code)
                .Select(i => new InventoryListItemDto
                {
                    InventoryId = i.Id,
                    ProductId = i.ProductId,
                    ProductCode = i.Product.Code,
                    ProductName = i.Product.Name,
                    StockQuantity = i.StockQuantity,
                    ReservedQuantity = i.ReservedQuantity
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
