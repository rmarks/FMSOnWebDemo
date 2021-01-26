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

        public async Task<DeliveryDropdowns> GetWarehouseReceiptDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByTypeCode("VL"),
                FromLocationTypes = await GetLocationTypes(),
                FromLocations = await GetLocations()
            };
        }

        public async Task<IDictionary<string, int>> GetLocationsByType(int typeId)
        {
            return await _context.Locations
                .AsNoTracking()
                .Where(l => l.LocationTypeId == typeId)
                .OrderBy(l => l.Name)
                .ToDictionaryAsync(l => l.Name, l => l.Id);
        }

        public async Task<DeliveryDropdowns> GetPurchaseReceiptDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByTypeCode("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetPurchaseShipmentDropdowns()
        {
            return new DeliveryDropdowns
            {
                FromLocations = await GetLocationsByTypeCode("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetProductionReceiptDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByTypeCode("VL"),
                FromLocations = await GetLocationsByTypeCode("TO")
            };

        }

        public async Task<DeliveryDropdowns> GetProductionShipmentDropdowns()
        {
            return new DeliveryDropdowns
            {
                FromLocations = await GetLocationsByTypeCode("VL"),
                ToLocations = await GetLocationsByTypeCode("TO")
            };

        }

        public async Task<DeliveryDropdowns> GetOutsourcingReceiptDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByTypeCode("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetOutsourcingShipmentDropdowns()
        {
            return new DeliveryDropdowns
            {
                FromLocations = await GetLocationsByTypeCode("VL")
            };
        }

        public async Task<DeliveryDropdowns> GetBetweenWarehousesDropdowns()
        {
            return new DeliveryDropdowns
            {
                ToLocations = await GetLocationsByTypeCode("VL"),
                FromLocations = await GetLocationsByTypeCode("VL")
            };
        }

        #region helpers
        private async Task<IDictionary<string, int>> GetLocationTypes()
        {
            return await _context.LocationTypes
                .AsNoTracking()
                .OrderBy(l => l.Name)
                .ToDictionaryAsync(l => l.Name, l => l.Id);
        }

        private async Task<IDictionary<string, int>> GetLocations()
        {
            return await _context.Locations
                .AsNoTracking()
                .OrderBy(l => l.LocationTypeId).ThenBy(l => l.Name)
                .ToDictionaryAsync(l => l.Name, l => l.Id);
        }

        private async Task<IDictionary<string, int>> GetLocationsByTypeCode(string typeCode)
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
