using FMS.Dal;
using FMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public class ListCustomersService : IListCustomersService
    {
        private readonly FMSDbContext _context;

        public ListCustomersService(FMSDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Customer>> FilterPage()
        {
            var queryable = _context.Customers
                .AsNoTracking()
                .Include(c => c.Addresses).ThenInclude(a => a.Country)
                .OrderBy(c => c.Name)
                .Take(10);

            return await queryable.ToListAsync();
        }
    }
}
