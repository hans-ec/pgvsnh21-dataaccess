using _01_EntityFrameworkCore_CodeFirst.Data;
using _01_EntityFrameworkCore_CodeFirst.Data.Entitites;
using _01_EntityFrameworkCore_CodeFirst.Models;
using _01_EntityFrameworkCore_CodeFirst.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFrameworkCore_CodeFirst.Services
{
    public interface ICustomerManager
    {
        Task CreateAsync(Customer customer);
        Task<Customer> GetAsync(int id);
        Task<Customer> GetAsync(string customerName);
        Task<IEnumerable<Customer>> GetAllAsync();
    }


    public class CustomerManager : ICustomerManager
    {
        private readonly DataContext _context;
        private readonly IContactPersonManager _contactPersonManager;

        public CustomerManager(DataContext context, IContactPersonManager contactPersonManager)
        {
            _context = context;
            _contactPersonManager = contactPersonManager;
        }

        public async Task CreateAsync(Customer customer)
        {
            if(!await _context.Customers.AnyAsync(x => x.Name == customer.CustomerName))
            {
                var customerEntity = new CustomerEntity
                {
                    Name = customer.CustomerName,
                    ContactPersonId = (await _contactPersonManager.CreateAsync(customer.ContactPerson)).Id
                };

                _context.Customers.Add(customerEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetAsync(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
