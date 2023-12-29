using Assignment.Shared.Interfaces;
using Assignment.Shared.Models;
using Assignment.Shared.Respository;

namespace Assignment.Tests;

public class ContactRepository_Tests
{
    /// <summary>
    ///     test to see that contacts are added to the list
    /// </summary>
    [Fact]
    public void AddContactToList_ShouldAddContactToContactList_ThenReturnTrue()
    {
        //arrange
        IContactModel contact = new ContactModel
        {
            Id = Guid.NewGuid(),
            FirstName = "Ann-Helen",
            LastName = "Lausmaa",
            PhoneNumber = "0700112233",
            Email = "annhelen@mail.se",
            Address = "Vinnargatan 1",
            ZipCode = "12345",
            City = "Drömstaden"
        };
        IContactRepository contactRepository = new ContactRepository();

        //act
        bool result = contactRepository.AddContactToList(contact);

        //assert
        Assert.True(result);
    }

    /// <summary>
    ///     test to see that the retrieval of contacts from the list is successful
    /// </summary>
    [Fact]
    public void GetAllContacts_ShouldGetAllContactsInList_ThenReturnListOfContacts()
    {
        //arrange
        IContactModel contact = new ContactModel
        {
            Id = Guid.NewGuid(),
            FirstName = "Ann-Helen",
            LastName = "Lausmaa",
            PhoneNumber = "0700112233",
            Email = "annhelen@mail.se",
            Address = "Vinnargatan 1",
            ZipCode = "12345",
            City = "Drömstaden"
        };
        IContactRepository contactRepository = new ContactRepository();
        contactRepository.AddContactToList(contact);

        //act
        IEnumerable<IContactModel> result = contactRepository.GetAllContacts();

        //assert
        Assert.NotNull(result);
        Assert.True(result.Any());
    }

    /// <summary>
    ///     test to see that the retrieval of one contact from the list is successful
    /// </summary>
    [Fact]
    public void GetOneContact_ShouldGetOneContactFromList_ThenReturnContact()
    {
        //arrange
        IContactModel contact = new ContactModel
        {
            Id = Guid.NewGuid(),
            FirstName = "Ann-Helen",
            LastName = "Lausmaa",
            PhoneNumber = "0700112233",
            Email = "annhelen@mail.se",
            Address = "Vinnargatan 1",
            ZipCode = "12345",
            City = "Drömstaden"
        };

        IContactRepository contactRepository = new ContactRepository();
        contactRepository.AddContactToList(contact);
        IEnumerable<IContactModel> _contacts = contactRepository.GetAllContacts();
        int position = 0;

        //act
        IContactModel result = contactRepository.GetOneContact(c => c.Id.Equals(_contacts.ElementAt(position).Id)); 

        //assert
        Assert.NotNull(result);
    }
}

