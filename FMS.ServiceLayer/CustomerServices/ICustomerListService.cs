using FMS.Domain.Models;
using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface ICustomerListService
    {
        PagedList<Customer> FilterPage(CustomerListOptions options);
        Task<IEnumerable<Customer>> SearchCustomers(string searchText);
    }
}