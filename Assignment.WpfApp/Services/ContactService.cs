using Assignment.Shared.Interfaces;
using Assignment.WpfApp.Interfaces;

namespace Assignment.WpfApp.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{
    private readonly IContactRepository _contactRepository = contactRepository;

    public IEnumerable<IContactModel> ShowAllContacts()
    {
        return _contactRepository.GetAllContacts();
    }

    public bool AddNewContact(IContactModel newContact)
    {
        bool result = _contactRepository.AddContactToList(newContact);
        return result;
    }

    public void ShowOneContact()
    {

    }

    public bool UpdateContact(IContactModel updatedContact)
    {
        bool result = _contactRepository.UpdateOneContact(x => x.Equals(updatedContact.Id), updatedContact);
        return result;
    } 

    public bool DeleteContact(Guid id)
    {
        bool result = _contactRepository.DeleteOneContact(x => x.Id.Equals(id));
        return result;
    }
}
