using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ReceiptDropdowns> GetReceiptDropdowns()
        {
            return new ReceiptDropdowns
            {
                WarehouseLocations = await _context.Locations
                    .AsNoTracking()
                    .Where(l => l.LocationType.Code == "VL")
                    .OrderBy(l => l.Name)
                    .ToDictionaryAsync(l => l.Name, l => l.Id)
            };
        }
    }
}
