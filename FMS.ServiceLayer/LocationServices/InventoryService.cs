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

            #region product filter
            if (options.ProductFilterOptions.ProductStatusId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductStatusId == options.ProductFilterOptions.ProductStatusId);
            }

            if (options.ProductFilterOptions.BusinessLineId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.BusinessLineId == options.ProductFilterOptions.BusinessLineId);
            }

            if (options.ProductFilterOptions.ProductSourceTypeId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductSourceTypeId == options.ProductFilterOptions.ProductSourceTypeId);
            }

            if (options.ProductFilterOptions.ProductDestinationTypeId != 0)
            {
                queryable = queryable.Where(p => p.Product.ProductBase.ProductDestinationTypeId == options.ProductFilterOptions.ProductDestinationTypeId);
            }

            if (options.ProductFilterOptions.ProductMaterialId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductMaterialId == options.ProductFilterOptions.ProductMaterialId);
            }

            if (options.ProductFilterOptions.ProductGroupId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductGroupId == options.ProductFilterOptions.ProductGroupId);
            }
            else if (options.ProductFilterOptions.ProductTypeId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductTypeId == options.ProductFilterOptions.ProductTypeId);
            }

            if (options.ProductFilterOptions.ProductDesignId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductDesignId == options.ProductFilterOptions.ProductDesignId);
            }
            else if (options.ProductFilterOptions.ProductCollectionId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductCollectionId == options.ProductFilterOptions.ProductCollectionId);
            }
            else if (options.ProductFilterOptions.ProductBrandId != 0)
            {
                queryable = queryable.Where(i => i.Product.ProductBase.ProductBrandId == options.ProductFilterOptions.ProductBrandId);
            }
            #endregion

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
