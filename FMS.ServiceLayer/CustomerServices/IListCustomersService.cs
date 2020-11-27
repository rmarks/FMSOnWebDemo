using FMS.Domain.Models;
using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface IListCustomersService
    {
        PagedList<Customer> FilterPage(CustomerListOptions options);
    }
}
