using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IDeliveryDropdownsService
    {
        Task<DeliveryDropdowns> GetOutsourcingReceiptDropdowns();
        Task<DeliveryDropdowns> GetOutsourcingShipmentDropdowns();

        Task<DeliveryDropdowns> GetProductionReceiptDropdowns();
        Task<DeliveryDropdowns> GetProductionShipmentDropdowns();

        Task<DeliveryDropdowns> GetPurchaseReceiptDropdowns();
        Task<DeliveryDropdowns> GetPurchaseShipmentDropdowns();
    }
}