namespace Assignment.Shared.Interfaces;

public interface IContactRepository
{
    bool AddContactToList(IContactModel contact);
    IEnumerable<IContactModel> GetAllContacts();
    IContactModel GetOneContact(Func<IContactModel, bool> predicate);
    IContactModel UpdateOneCOntact(Func<IContactModel, bool> predicate);
    bool DeleteContact(Func<IContactModel, bool> predicate);
}
