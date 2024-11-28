
using DekstopContactApp.DataBase;
using DekstopContactApp.Interfaces;
using DekstopContactApp.Modules;

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
    }

}
