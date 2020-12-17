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
            var queryable = _context.Customers
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(options.SearchByName))
            {
                queryable = queryable.Where(c => c.Name.ToLower().Contains(options.SearchByName.ToLower()));
            }

            if (options.CountryId != 0)
            {
                queryable = queryable.Where(c => c.Addresses.Any(a => a.IsBilling && a.CountryId == options.CountryId));
            }

            if (!string.IsNullOrWhiteSpace(options.SearchByCity))
            {
                queryable = queryable.Where(c => c.Addresses.Any(a => a.IsBilling && a.City.ToLower().Contains(options.SearchByCity.ToLower())));
            }

            if (options.PaymentTermId != 0)
            {
                queryable = queryable.Where(c => c.PaymentTermId == options.PaymentTermId);
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
