using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IProductionReceiptService
    {
        PagedList<ReceiptListItemDto> FilterPage(ReceiptListOptions options);
    }
}