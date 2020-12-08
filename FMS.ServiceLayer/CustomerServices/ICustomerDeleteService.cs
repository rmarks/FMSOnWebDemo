using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface ICustomerDeleteService
    {
        Task DeleteCustomer(int id);
    }
}