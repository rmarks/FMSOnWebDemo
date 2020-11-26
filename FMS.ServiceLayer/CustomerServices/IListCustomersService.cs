using FMS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public interface IListCustomersService
    {
        Task<IList<Customer>> FilterPage();
    }
}
