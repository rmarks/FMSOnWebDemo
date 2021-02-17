using FMS.Dal;
using FMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.CustomerServices
{
    public class CustomerUpdateService : ICustomerUpdateService
    {
        private readonly FMSContext _context;

        public CustomerUpdateService(FMSContext context)
        {
            _context = context;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            if (customer.Id != 0)
            {
                var existingCustomer = _context.Customers
                    .Include(c => c.Addresses)
                    .Include(c => c.Contacts)
                    .FirstOrDefault(c => c.Id == customer.Id);

                // Update Existing Customer
                // update modified datetime
                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);

                // Delete Contacts
                foreach (var existingContact in existingCustomer.Contacts.ToList())
                {
                    if (!customer.Contacts.Any(c => c.Id == existingContact.Id))
                    {
                        _context.CustomerContacts.Remove(existingContact);
                    }
                }

                // Update or Insert Contacts
                foreach (var contact in customer.Contacts)
                {
                    var existingContact = existingCustomer.Contacts.FirstOrDefault(ec => ec.Id == contact.Id);
                    if (existingContact != null)
                    {
                        _context.Entry(existingContact).CurrentValues.SetValues(contact);
                    }
                    else
                    {
                        var newContact = new CustomerContact
                        {
                            Id = contact.Id,
                            Name = contact.Name,
                            Job = contact.Job,
                            Mobile = contact.Mobile,
                            Phone = contact.Phone,
                            Email = contact.Email
                        };

                        existingCustomer.Contacts.Add(newContact);
                    }
                }

                // Delete Consignee Addresses
                foreach (var existingAddress in existingCustomer.Addresses.ToList())
                {
                    if (!customer.Addresses.Any(a => a.Id == existingAddress.Id))
                    {
                        _context.CustomerAddresses.Remove(existingAddress);
                    }
                }

                // Update and Insert Addresses
                foreach (var address in customer.Addresses)
                {
                    var existingAddress = existingCustomer.Addresses.FirstOrDefault(a => a.Id == address.Id);

                    if (existingAddress != null)
                    {
                        _context.Entry(existingAddress).CurrentValues.SetValues(address);
                    }
                    else
                    {
                        var newAddress = new CustomerAddress
                        {
                            Id = address.Id,
                            CountryId = address.CountryId,
                            County = address.County,
                            City = address.City,
                            Address = address.Address,
                            PostCode = address.PostCode,
                            ConsigneeName = address.ConsigneeName
                        };

                        existingCustomer.Addresses.Add(newAddress);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
