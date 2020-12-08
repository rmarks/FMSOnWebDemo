using FMS.Domain.Models;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface ICustomerUpdateService
    {
        Task UpdateCustomer(Customer customer);
    }
}