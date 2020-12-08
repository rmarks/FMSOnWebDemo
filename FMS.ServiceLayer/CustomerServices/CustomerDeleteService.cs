using FMS.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public class CustomerDeleteService : ICustomerDeleteService
    {
        private readonly FMSContext _context;

        public CustomerDeleteService(FMSContext context)
        {
            _context = context;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Contacts)
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == id);

            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
