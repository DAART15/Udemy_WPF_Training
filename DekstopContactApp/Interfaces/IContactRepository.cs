
using DekstopContactApp.Modules;

namespace DekstopContactApp.Interfaces
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
        Task<List<Contact>> GetAllContactsAsync();
        Task DeleteContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
    }
}
