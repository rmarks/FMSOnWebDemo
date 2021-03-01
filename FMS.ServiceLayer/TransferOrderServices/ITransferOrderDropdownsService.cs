using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.TransferOrderServices
{
    public interface ITransferOrderDropdownsService
    {
        Task<TransferOrderDropdowns> GetCommissionTransferOrderDropdowns();
    }
}