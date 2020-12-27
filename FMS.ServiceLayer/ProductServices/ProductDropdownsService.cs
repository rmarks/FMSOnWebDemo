using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
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
    }
}
