using Assignment.Shared.Interfaces;
using Assignment.Shared.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Assignment.Shared.Respository;

public class ContactRepository : IContactRepository
{
    //instantiate: the reusable list and fileService
    private List<IContactModel> _contactList = [];
    private readonly FileService _fileService =  new FileService(@"c:\Work\EC\3-c-sharp\Testfolder\adressBook.json");
    private readonly JsonSerializerSettings _jsonSettings = new() { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };

    //method: CREATE contact to list
    public bool AddContactToList(IContactModel contact)
    {
        try
        {
            _contactList.Add(contact);
            
            string jsonContent = JsonConvert.SerializeObject(_contactList, _jsonSettings);

            bool result = _fileService.SaveContactListToFile(jsonContent);

            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    //method: READ all contacts
    public IEnumerable<IContactModel> GetAllContacts()
    {
        try
        {
            string content = _fileService.GetContactListFromFile();

            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, _jsonSettings)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return _contactList;
    }


    //method: READ one contact - based on firstname
    public IContactModel GetOneContact(Func<IContactModel, bool> predicate)
    {
        IContactModel contact = _contactList.FirstOrDefault(predicate)!;

        if (contact != null)
        {
            return contact;
        }

        return null!;
    }


    //method: UPDATE one contact - based on firstname
    public bool UpdateOneContact(Func<IContactModel, bool> predicate, IContactModel updatedContact)
    {
        try
        {
            IContactModel contact = _contactList.FirstOrDefault(predicate)!;

            if(contact != null)
            {
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName; 
                contact.PhoneNumber = updatedContact.PhoneNumber;
                contact.Email = updatedContact.Email;
                contact.Address = updatedContact.Address;
                contact.ZipCode = updatedContact.ZipCode;
                contact.City = updatedContact.City;
            }

            string jsonContent = JsonConvert.SerializeObject(_contactList, _jsonSettings);

            bool result = _fileService.SaveContactListToFile(jsonContent);

            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

 
    //method: DELETE one contact - based on e-mail
    public bool DeleteOneContact(Func<IContactModel, bool> predicate)
    {
        try
        {
            IContactModel contact = _contactList.FirstOrDefault(predicate)!;
            
            _contactList.Remove(contact);

            string jsonContent = JsonConvert.SerializeObject(_contactList, _jsonSettings);

            bool result = _fileService.SaveContactListToFile(jsonContent);

            return result;

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
