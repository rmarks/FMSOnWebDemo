using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IOutsourcingDeliveryService
    {
        PagedList<DeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options);
        PagedList<DeliveryListItemDto> ShipmentFilterPage(DeliveryListOptions options);
    }
}