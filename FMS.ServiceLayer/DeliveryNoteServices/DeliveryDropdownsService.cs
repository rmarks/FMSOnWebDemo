using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class DeliveryDropdownsService : IDeliveryDropdownsService
    {
        private readonly FMSContext _context;

        public DeliveryDropdownsService(FMSContext context)
        {
            _context = context;
        }

        public async Task<DeliveryDropdowns> GetPurchaseReceiptDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByType("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetPurchaseShipmentDropdowns()
        {
            return new DeliveryDropdowns
            {
                FromLocations = await GetLocationsByType("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetProductionReceiptDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByType("VL"),
                FromLocations = await GetLocationsByType("TO")
            };

        }

        public async Task<DeliveryDropdowns> GetProductionShipmentDropdowns()
        {
            return new DeliveryDropdowns
            {
                FromLocations = await GetLocationsByType("VL"),
                ToLocations = await GetLocationsByType("TO")
            };

        }

        public async Task<DeliveryDropdowns> GetOutsourcingReceiptDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByType("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetOutsourcingShipmentDropdowns()
        {
            return new DeliveryDropdowns
            {
                FromLocations = await GetLocationsByType("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetBetweenWarehousesDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByType("VL"),
                FromLocations = await GetLocationsByType("VL")
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
