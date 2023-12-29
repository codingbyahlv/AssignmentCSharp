using Assignment.Shared.Interfaces;
using Assignment.WpfApp.Interfaces;

namespace Assignment.WpfApp.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{
    private readonly IContactRepository _contactRepository = contactRepository;

    //method: calls the shared GetAllContacts method
    public IEnumerable<IContactModel> ShowAllContacts()
    {
        return _contactRepository.GetAllContacts();
    }


    //method: calls the shared AddContactToList method
    public bool AddNewContact(IContactModel newContact)
    {
        bool result = _contactRepository.AddContactToList(newContact);
        return result;
    }


    //method: calls the shared UpdateOneContact method
    public bool UpdateContact(IContactModel updatedContact)
    {
        bool result = _contactRepository.UpdateOneContact(x => x.Equals(updatedContact.Id), updatedContact);
        return result;
    } 

   //method: calls the shared DeleteOneContact method
    public bool DeleteContact(Guid id)
    {
        bool result = _contactRepository.DeleteOneContact(x => x.Id.Equals(id));
        return result;
    }
}
