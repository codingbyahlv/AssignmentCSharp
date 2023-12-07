using ConsoleApp.Models;

namespace ConsoleApp.Interfaces
{
    public interface IContactRespository
    {
        bool AddContactToList(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        //IContact GetOneContact(string FirstName);
        IContact GetOneContact(Func<IContact, bool> predicate);
        bool DeleteContact(string Email);
    }
}