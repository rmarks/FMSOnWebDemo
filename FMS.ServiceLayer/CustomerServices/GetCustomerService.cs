using FMS.Dal;
using FMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public class GetCustomerService : IGetCustomerService
    {
        private readonly FMSContext _context;

        public GetCustomerService(FMSContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _context.Customers
                .AsNoTracking()
                .Include(c => c.PaymentTerm)
                .Include(c => c.Addresses).ThenInclude(a => a.Country)
                .Include(c => c.Contacts)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
