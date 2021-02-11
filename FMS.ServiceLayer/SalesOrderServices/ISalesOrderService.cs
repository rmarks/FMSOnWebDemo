using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.SalesOrderServices
{
    public interface ISalesOrderService
    {
        Task<SalesOrderDto> GetOrder(int id);
    }
}