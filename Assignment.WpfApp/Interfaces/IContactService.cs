using Assignment.Shared.Interfaces;

namespace Assignment.WpfApp.Interfaces;

public interface IContactService
{
    /// <summary>
    ///     Calls the shared GetAllContacts method
    /// </summary>
    /// <returns>The list as a result from the GetAllContacts method</returns>
    IEnumerable<IContactModel> ShowAllContacts();

    /// <summary>
    ///     Calls the shared AddContactToList method
    /// </summary>
    /// <param name="newContact">The new contact information</param>
    /// <returns>True if added correctly to the file, false when there is any problem with the save</returns>
    bool AddNewContact(IContactModel newContact);

    /// <summary>
    ///     Calls the shared UpdateOneContact method
    /// </summary>
    /// <param name="updatedContact">The updated contact information</param>
    /// <returns>True if correctly updated, false when there is any problem with the update</returns>
    bool UpdateContact(IContactModel updatedContact);

    /// <summary>
    ///     Calls the shared DeleteOneContact method
    /// </summary>
    /// <param name="id">The contact id that should be deleted</param>
    /// <returns>True if correctly removed, false when there is any problem with the delete</returns>
    bool DeleteContact(Guid id);
}
