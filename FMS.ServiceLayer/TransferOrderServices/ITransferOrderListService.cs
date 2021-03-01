using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.TransferOrderServices
{
    public interface ITransferOrderListService
    {
        PagedList<TransferOrderListItemDto> GetPage(TransferOrderOptions options);
    }
}