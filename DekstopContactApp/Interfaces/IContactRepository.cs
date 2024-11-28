
using DekstopContactApp.Modules;

namespace DekstopContactApp.Interfaces
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
    }
}
