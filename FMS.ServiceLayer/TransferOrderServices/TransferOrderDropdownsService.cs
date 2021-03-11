using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.TransferOrderServices
{
    public class TransferOrderDropdownsService : ITransferOrderDropdownsService
    {
        private readonly FMSContext _context;

        public TransferOrderDropdownsService(FMSContext context)
        {
            _context = context;
        }

        public async Task<TransferOrderListDropdowns> GetCommissionTransferOrderListDropdowns()
        {
            return new TransferOrderListDropdowns
            {
                CommissionLocations = await GetLocationsByTypeCode("KL")
            };
        }

        public async Task<TransferOrderDropdowns> GetCommissionTransferOrderDropdowns()
        {
            return new TransferOrderDropdowns
            {
                CommissionLocations = await GetLocationsByTypeCode("KL"),
                WarehouseLocations = await GetLocationsByTypeCode("VL")
            };
        }

        #region helpers
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
