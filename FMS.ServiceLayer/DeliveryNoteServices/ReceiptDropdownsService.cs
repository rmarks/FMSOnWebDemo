using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class ReceiptDropdownsService : IReceiptDropdownsService
    {
        private readonly FMSContext _context;

        public ReceiptDropdownsService(FMSContext context)
        {
            _context = context;
        }

        public async Task<ReceiptDropdowns> GetPurchaseReceiptDropdowns()
        {
            return new ReceiptDropdowns
            {
                ToLocations = await GetLocationsByType("VL")
            };
        }

        public async Task<ReceiptDropdowns> GetProductionReceiptDropdowns()
        {
            return new ReceiptDropdowns
            {
                ToLocations = await GetLocationsByType("VL"),
                FromLocations = await GetLocationsByType("TO")
            };

        }

        public async Task<ReceiptDropdowns> GetOutSourcingReceiptDropdowns()
        {
            return new ReceiptDropdowns
            {
                ToLocations = await GetLocationsByType("VL")
            };
        }

        #region helpers
        private async Task<IDictionary<string, int>> GetLocationsByType(string typeCode)
        {
            return await _context.Locations
                .AsNoTracking()
                .Where(l => l.LocationType.Code == typeCode)
                .OrderBy(l => l.Name)
                .ToDictionaryAsync(l => l.Name, l => l.Id);
        }
        #endregion 
    }
}
