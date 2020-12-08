using FMS.Domain.Models;
using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface ICustomerListService
    {
        PagedList<Customer> FilterPage(CustomerListOptions options);
    }
}