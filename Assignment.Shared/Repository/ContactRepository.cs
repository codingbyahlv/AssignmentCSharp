using Assignment.Shared.Interfaces;
using Assignment.Shared.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Assignment.Shared.Respository;

public class ContactRepository : IContactRepository
{
    //instantiate: the reusable list, fileService and jsonSettings
    private List<IContactModel> _contactList = [];
    private readonly FileService _fileService = new FileService(Path.Combine(FindSolutionDirectory(), "adressBook.json"));
    private readonly JsonSerializerSettings _jsonSettings = new() { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };


    //method: find the current solution filepath for the json file
    static string FindSolutionDirectory()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string? solutionDirectory = currentDirectory;

        while (Directory.GetFiles(solutionDirectory, "*.sln").Length == 0)
        {
            solutionDirectory = Directory.GetParent(solutionDirectory)?.FullName;

            if (solutionDirectory == null)
            {
                throw new InvalidOperationException("Solution mapp hittas inte.");
            }
        }

        return solutionDirectory;
    }


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


    //method: READ one contact
    public IContactModel GetOneContact(Func<IContactModel, bool> predicate)
    {
        IContactModel contact = _contactList.FirstOrDefault(predicate)!;

        if (contact != null)
        {
            return contact;
        }

        return null!;
    }


    //method: UPDATE one contact
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

 
    //method: DELETE one contact
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
