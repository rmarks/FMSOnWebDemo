using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IDeliveryDropdownsService
    {
        Task<DeliveryDropdowns> GetWarehouseReceiptDropdowns();
        Task<DeliveryDropdowns> GetWarehouseShipmentDropdowns();

        Task<IDictionary<string, int>> GetLocationsByType(int typeId);

        Task<DeliveryDropdowns> GetOneSideReceiptDropdowns();
        Task<DeliveryDropdowns> GetOneSideShipmentDropdowns();
    }
}