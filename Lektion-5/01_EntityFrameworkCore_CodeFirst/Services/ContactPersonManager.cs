using _01_EntityFrameworkCore_CodeFirst.Data;
using _01_EntityFrameworkCore_CodeFirst.Data.Entitites;
using _01_EntityFrameworkCore_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFrameworkCore_CodeFirst.Services
{
    public interface IContactPersonManager
    {
        Task<ContactPerson> CreateAsync(ContactPerson contact);
        Task<ContactPerson> GetAsync(int id);
        Task<ContactPerson> GetAsync(string émail);
    }
    public class ContactPersonManager : IContactPersonManager
    {
        private readonly DataContext _context;

        public ContactPersonManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ContactPerson> CreateAsync(ContactPerson contact)
        {
            var contactPersonEntity = await _context.ContactPeople.FirstOrDefaultAsync(x => x.Email == contact.Email);
            if (contactPersonEntity == null)
            {
                contactPersonEntity = new ContactPersonEntity
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email
                };

                _context.ContactPeople.Add(contactPersonEntity);
                await _context.SaveChangesAsync();
            }

            return new ContactPerson
            {
                Id = contactPersonEntity.Id,
                FirstName = contactPersonEntity.FirstName,
                LastName = contactPersonEntity.LastName,
                Email = contactPersonEntity.Email
            };
        }

        public async Task<ContactPerson> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactPerson> GetAsync(string émail)
        {
            throw new NotImplementedException();
        }
    }
}
