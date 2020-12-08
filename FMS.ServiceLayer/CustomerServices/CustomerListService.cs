using FMS.Dal;
using FMS.Domain.Models;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public class CustomerListService : ICustomerListService
    {
        private readonly FMSContext _context;

        public CustomerListService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<Customer> FilterPage(CustomerListOptions options)
        {
            string search = options.SearchString;

            var queryable = _context.Customers
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                queryable = queryable.Where(c => c.Name.ToLower().Contains(search.ToLower()));
            }

            return queryable
                .Include(c => c.Addresses).ThenInclude(a => a.Country)
                .OrderBy(c => c.Name)
                .GetPagedList(options.CurrentPage, options.PageSize);
        }

        public async Task<IEnumerable<Customer>> SearchCustomers(string searchText)
        {
            return await _context.Customers
                .AsNoTracking()
                .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
