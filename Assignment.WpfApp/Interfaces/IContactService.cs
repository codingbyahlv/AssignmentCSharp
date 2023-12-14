using Assignment.Shared.Interfaces;

namespace Assignment.WpfApp.Interfaces;

public interface IContactService
{
    IEnumerable<IContactModel> ShowAllContacts();

    bool AddNewContact(IContactModel newContact);

    bool UpdateContact(IContactModel updatedContact);

    bool DeleteContact(Guid id);
}
