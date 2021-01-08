using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IOutsourcingReceiptService
    {
        PagedList<ReceiptListItemDto> FilterPage(ReceiptListOptions options);
    }
}