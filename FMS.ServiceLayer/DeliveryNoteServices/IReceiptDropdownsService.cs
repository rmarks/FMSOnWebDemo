using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IReceiptDropdownsService
    {
        Task<ReceiptDropdowns> GetOutSourcingReceiptDropdowns();
        Task<ReceiptDropdowns> GetProductionReceiptDropdowns();
        Task<ReceiptDropdowns> GetPurchaseReceiptDropdowns();
    }
}