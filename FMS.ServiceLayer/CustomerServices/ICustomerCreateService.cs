using FMS.Domain.Models;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface ICustomerCreateService
    {
        Task CreateCustomer(Customer customer);
    }
}