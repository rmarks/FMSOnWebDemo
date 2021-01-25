using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface ILocationDeliveryService
    {
        PagedList<LocationDeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options);
    }
}