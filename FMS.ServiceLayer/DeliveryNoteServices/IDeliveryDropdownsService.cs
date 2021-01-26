using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IDeliveryDropdownsService
    {
        Task<DeliveryDropdowns> GetWarehouseReceiptDropdowns();

        Task<IDictionary<string, int>> GetLocationsByType(int typeId);

        Task<DeliveryDropdowns> GetOutsourcingReceiptDropdowns();
        Task<DeliveryDropdowns> GetOutsourcingShipmentDropdowns();

        Task<DeliveryDropdowns> GetProductionReceiptDropdowns();
        Task<DeliveryDropdowns> GetProductionShipmentDropdowns();

        Task<DeliveryDropdowns> GetPurchaseReceiptDropdowns();
        Task<DeliveryDropdowns> GetPurchaseShipmentDropdowns();

        Task<DeliveryDropdowns> GetBetweenWarehousesDropdowns();
    }
}