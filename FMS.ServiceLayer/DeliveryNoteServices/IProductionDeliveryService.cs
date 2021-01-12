using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IProductionDeliveryService
    {
        PagedList<DeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options);
        PagedList<DeliveryListItemDto> ShipmentFilterPage(DeliveryListOptions options);
    }
}