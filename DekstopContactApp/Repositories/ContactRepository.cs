using DekstopContactApp.DataBase;
using DekstopContactApp.Interfaces;
using DekstopContactApp.Modules;
using Microsoft.EntityFrameworkCore;

namespace DekstopContactApp.Repositories
{
    public class ContactRepository(AppDbContext dbContext) : IContactRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task AddContactAsync(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }
        public async Task DeleteContactAsync(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateContactAsync(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }
    }

}
