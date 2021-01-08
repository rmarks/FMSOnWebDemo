using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IPurchaseReceiptService
    {
        PagedList<ReceiptListItemDto> FilterPage(ReceiptListOptions options);
    }
}