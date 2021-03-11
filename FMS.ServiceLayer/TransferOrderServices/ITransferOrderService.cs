using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.TransferOrderServices
{
    public interface ITransferOrderService
    {
        Task<TransferOrderDto> GetOrder(int id);
    }
}