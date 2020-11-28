using FMS.Domain.Models;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface IGetCustomerService
    {
        Task<Customer> GetCustomer(int id);
    }
}