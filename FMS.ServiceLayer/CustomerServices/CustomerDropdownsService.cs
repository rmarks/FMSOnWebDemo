using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public class CustomerDropdownsService : ICustomerDropdownsService
    {
        private readonly FMSContext _context;

        public CustomerDropdownsService(FMSContext context)
        {
            _context = context;
        }

        public async Task<CustomerDropdowns> GetCustomerDropdowns()
        {
            var countries = await _context.Countries
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToDictionaryAsync(c => c.Name, c => c.Id);

            var dropdowns = new CustomerDropdowns
            {
                Countries = countries
            };

            return dropdowns;
        }
    }
}
