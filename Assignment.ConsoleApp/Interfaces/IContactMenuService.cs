using Assignment.Shared.Interfaces;

namespace Assignment.ConsoleApp.Interfaces;

public interface IContactMenuService
{
    /// <summary>
    ///     Shows all contacts in the list
    /// </summary>
    void ShowAllContacts();

    /// <summary>
    ///     Add a new contact to the list
    /// </summary>
    void AddNewContact();

    /// <summary>
    ///     Show one of the contacts in the list
    /// </summary>
    /// <param name="input">The input indicates the position in the list from which the contact should be retrieved</param>
    void ShowOneContact(string input);

    /// <summary>
    ///     Update current contact
    /// </summary>
    /// <param name="id">The contact id specifies which id that should be updated</param>
    void UpdateContact(Guid id);

    /// <summary>
    ///     Delete current contact
    /// </summary>
    /// <param name="id">The contact id specifies which id that should be removed</param>
    void DeleteContact(Guid id);
}
