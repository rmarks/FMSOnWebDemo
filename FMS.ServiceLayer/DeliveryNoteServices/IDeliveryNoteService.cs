using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public interface IDeliveryNoteService
    {
        Task<DeliveryNoteDto> GetDeliveryNoteDocument(int id);
    }
}