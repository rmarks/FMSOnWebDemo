using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface ICustomerDropdownsService
    {
        Task<CustomerDropdowns> GetCustomerDropdowns();
    }
}