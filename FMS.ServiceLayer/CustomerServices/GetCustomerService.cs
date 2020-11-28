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
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
