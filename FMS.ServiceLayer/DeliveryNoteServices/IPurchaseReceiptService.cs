using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IPurchaseReceiptService
    {
        PagedList<DeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options);
        PagedList<DeliveryListItemDto> ShipmentFilterPage(DeliveryListOptions options);
    }
}