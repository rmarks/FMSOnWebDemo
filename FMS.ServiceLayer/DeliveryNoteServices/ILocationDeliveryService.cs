using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface ILocationDeliveryService
    {
        PagedList<LocationDeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options);
        PagedList<LocationDeliveryListItemDto> ShipmentFilterPage(DeliveryListOptions options);
    }
}