using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.ProductServices
{
    public class ProductBaseService : IProductBaseService
    {
        private readonly FMSContext _context;

        public ProductBaseService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<ProductBaseListDto> GetFilterPage(ProductListOptions options)
        {
            var queryable = _context.ProductBases
                .AsNoTracking();

            if (options.ProductStatusId != 0)
            {
                queryable = queryable.Where(p => p.ProductStatusId == options.ProductStatusId);
            }

            if (options.BusinessLineId != 0)
            {
                queryable = queryable.Where(p => p.BusinessLineId == options.BusinessLineId);
            }

            if (options.ProductSourceTypeId != 0)
            {
                queryable = queryable.Where(p => p.ProductSourceTypeId == options.ProductSourceTypeId);
            }

            if (options.ProductDestinationTypeId != 0)
            {
                queryable = queryable.Where(p => p.ProductDestinationTypeId == options.ProductDestinationTypeId);
            }

            if (options.ProductMaterialId != 0)
            {
                queryable = queryable.Where(p => p.ProductMaterialId == options.ProductMaterialId);
            }

            if (options.ProductGroupId != 0)
            {
                queryable = queryable.Where(p => p.ProductGroupId == options.ProductGroupId);
            }
            else if (options.ProductTypeId != 0)
            {
                queryable = queryable.Where(p => p.ProductTypeId == options.ProductTypeId);
            }

            if (options.ProductDesignId != 0)
            {
                queryable = queryable.Where(p => p.ProductDesignId == options.ProductDesignId);
            }
            else if (options.ProductCollectionId != 0)
            {
                queryable = queryable.Where(p => p.ProductCollectionId == options.ProductCollectionId);
            }
            else if (options.ProductBrandId != 0)
            {
                queryable = queryable.Where(p => p.ProductBrandId == options.ProductBrandId);
            }

            return queryable
                .OrderBy(p => p.Code)
                .Select(p => new ProductBaseListDto
                {
                    ProductBaseId = p.Id,
                    ProductBaseCode = p.Code,
                    ProductBaseName = p.Name,
                    StockQuantity = p.Products
                        .SelectMany(p => p.Inventory)
                        .Where(i => options.LocationId == 0 ? true : i.LocationId == options.LocationId)
                        .Sum(i => i.StockQuantity),
                    //ReservedQuantity = p.Products.Sum(p => p.ProductInventory.Sum(i => i.ReservedQuantity))
                    ReservedQuantity = p.Products
                        .SelectMany(p => p.Inventory)
                        .Where(i => options.LocationId == 0 ? true : i.LocationId == options.LocationId)
                        .Sum(i => i.ReservedQuantity)
                })
                .Where(p => options.Stock == Stock.OnlyInStock ? p.StockQuantity > 0 : (options.Stock == Stock.NotInStock ? p.StockQuantity == 0 : true ))
                .GetPagedList(options.CurrentPage, options.PageSize);
        }

        public ProductBaseInfoDto GetProductBaseInfo(ProductBaseInfoDto info)
        {
            info.Locations = _context.Locations
                .AsNoTracking()
                .Where(l => l.Inventory.Any(i => i.Product.ProductBaseId == info.ProductBaseId))
                .Select(l => new LocationInventoryDto
                {
                    LocationId = l.Id,
                    LocationName = l.Name,
                    Products = l.Inventory
                        .Where(i => i.Product.ProductBaseId == info.ProductBaseId)
                        .Select(i => new ProductInStockDto
                        {
                            LocationId = i.LocationId,
                            ProductCode = i.Product.Code,
                            StockQuantity = i.StockQuantity,
                            ReservedQuantity = i.ReservedQuantity
                        })
                        .Where(p => p.StockQuantity > 0)
                        .OrderBy(p => p.ProductCode)
                        .ToList()
                })
                .Where(wi => wi.Products.Count > 0)
                .ToList();

            return info;
        }
    }
}
