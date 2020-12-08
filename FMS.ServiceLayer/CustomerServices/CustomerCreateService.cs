using FMS.Dal;
using FMS.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public class CustomerCreateService : ICustomerCreateService
    {
        private readonly FMSContext _context;

        public CustomerCreateService(FMSContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                customer.CreatedOn = DateTime.Now;

                if (customer.PayerAddress.Country != null)
                {
                    customer.PayerAddress.Country = null;
                }

                if (customer.PayerAddress.Id == 0)
                {
                    customer.Addresses.Add(customer.PayerAddress);
                }

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
