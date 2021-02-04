using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.ProductServices
{
    public class ProductDropdownsService : IProductDropdownsService
    {
        private readonly FMSContext _context;

        public ProductDropdownsService(FMSContext context)
        {
            _context = context;
        }

        public async Task<ProductDropdowns> GetProductDropdowns()
        {
            return new ProductDropdowns
            {
                ProductStatuses = await _context.ProductStatuses.AsNoTracking().OrderBy(p => p.Name).ToListAsync(),
                BusinessLines = await _context.BusinessLines.AsNoTracking().ToListAsync(),
                ProductSourceTypes = await _context.ProductSourceTypes.AsNoTracking().OrderBy(p => p.Name).ToListAsync(),
                ProductDestinationTypes = await _context.ProductDestinationTypes.AsNoTracking().OrderBy(p => p.Name).ToListAsync(),
                ProductMaterials = await _context.ProductMaterials.AsNoTracking().ToListAsync(),
                ProductTypes = await _context.ProductTypes.AsNoTracking().ToListAsync(),
                ProductGroups = await _context.ProductGroups.AsNoTracking().ToListAsync(),
                ProductBrands = await _context.ProductBrands.AsNoTracking().ToListAsync(),
                ProductCollections = await _context.ProductCollections.AsNoTracking().ToListAsync(),
                ProductDesigns = await _context.ProductDesigns.AsNoTracking().ToListAsync(),
                Locations = await _context.Locations.AsNoTracking().OrderBy(l => l.Name).ToListAsync()
            };
        }

        public async Task<ProductFilterDropdowns> GetProductFilterDropdowns()
        {
            return new ProductFilterDropdowns
            {
                ProductStatuses = await _context.ProductStatuses.AsNoTracking().OrderBy(p => p.Name).ToDictionaryAsync(p => p.Id, p => p.Name),
                BusinessLines = await _context.BusinessLines.AsNoTracking().ToDictionaryAsync(b => b.Id, b => b.Name),
                ProductSourceTypes = await _context.ProductSourceTypes.AsNoTracking().OrderBy(p => p.Name).ToDictionaryAsync(p => p.Id, p => p.Name),
                ProductDestinationTypes = await _context.ProductDestinationTypes.AsNoTracking().OrderBy(p => p.Name).ToDictionaryAsync(p => p.Id, p => p.Name),
                ProductMaterials = await _context.ProductMaterials.AsNoTracking().ToDictionaryAsync(p => p.Id, p => p.Name),
                ProductTypes = await _context.ProductTypes.AsNoTracking().ToDictionaryAsync(p => p.Id, p => p.Name),
                ProductGroups = await GetProductGroupsByType(),
                ProductBrands = await _context.ProductBrands.AsNoTracking().ToDictionaryAsync(p => p.Id, p => p.Name),
                ProductCollections = await GetProductCollectionsByBrand(),
                ProductDesigns = await GetProductDesignsByCollection()
            };
        }

        public async Task<IDictionary<int, string>> GetProductGroupsByType(int productTypeId = 2)
        {
            if (productTypeId == 0) return new Dictionary<int, string>();

            var dict = await _context.ProductGroups
                .AsNoTracking()
                .Where(p => p.ProductTypeId == productTypeId)
                .ToDictionaryAsync(p => p.Id, p => p.Name);

            return dict;
        }

        public async Task<IDictionary<int, string>> GetProductCollectionsByBrand(int productBrandId = 0)
        {
            if (productBrandId == 0) return new Dictionary<int, string>();

            return await _context.ProductCollections
                .AsNoTracking()
                .Where(p => p.ProductBrandId == productBrandId)
                .ToDictionaryAsync(p => p.Id, p => p.Name);
        }

        public async Task<IDictionary<int, string>> GetProductDesignsByCollection(int productCollectionId = 0)
        {
            if (productCollectionId == 0) return new Dictionary<int, string>();

            return await _context.ProductDesigns
                .AsNoTracking()
                .Where(p => p.ProductCollectionId == productCollectionId)
                .ToDictionaryAsync(p => p.Id, p => p.Name);
        }
    }
}
