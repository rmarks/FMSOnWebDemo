using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.TransferOrderServices
{
    public interface ITransferOrderService
    {
        Task<TransferOrderDto> GetOrder(int id);
        Task<IList<TransferOrderLineDto>> GetOrderLinesAsync(int orderId);

        Task<TransferOrderHeaderDto> CreateOrderHeaderAsync(TransferOrderHeaderDto dto);
        Task<TransferOrderHeaderDto> ReadOrderHeaderAsync(int id);
        Task UpdateOrderHeaderAsync(TransferOrderHeaderDto dto);
        Task<bool> DeleteOrderAsync(int id);
    }
}