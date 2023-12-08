namespace Assignment.Shared.Interfaces;

public interface IContactRepository
{
    /// <summary>
    ///     Add a contact to the contactlist and save/update the json file
    /// </summary>
    /// <param name="contact">A contact created by the user</param>
    /// <returns>True if added correctly to the file, false when there is any problem with the save</returns>
    bool AddContactToList(IContactModel contact);

    /// <summary>
    ///     Get all contacts from the contactList
    /// </summary>
    /// <returns>A readonly list with all contacts</returns>
    IEnumerable<IContactModel> GetAllContacts();

    /// <summary>
    ///     Get one contact based on user input
    /// </summary>
    /// <param name="predicate">Get the contact where the firstname matches the user input</param>
    /// <returns>The found contact</returns>
    IContactModel GetOneContact(Func<IContactModel, bool> predicate);

    /// <summary>
    ///     Update current contact
    /// </summary>
    /// <param name="predicate">Get the contact where when the email matches the contact the user is currently viewing, and the new contact information</param>
    /// <returns>True if correctly updated, false when there is any problem with the update</returns>
    bool UpdateOneContact(Func<IContactModel, bool> predicate, IContactModel contact);

    /// <summary>
    ///     Delete current contact
    /// </summary>
    /// <param name="predicate">Get the contact where when the email matches the contact the user is currently viewing</param>
    /// <returns>True if correctly removed, false when there is any problem with the delete</returns>
    bool DeleteOneContact(Func<IContactModel, bool> predicate);
}
