using Assignment.Shared.Interfaces;
using Assignment.Shared.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Assignment.Shared.Respository;

public class ContactRespository : IContactRepository
{
    //instantiate: the reusable list
    private List<IContactModel> _contactList = [];
    //instantiate: the fileService for saving content to file
    private readonly FileService _fileService =  new();


    //method: CREATE person to list
    public bool AddContactToList(IContactModel contact)
    {
        try
        {
            _contactList.Add(contact);
            
            string jsonContent = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings 
            { 
                TypeNameHandling = TypeNameHandling.All, 
                Formatting = Formatting.Indented
            });

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
                _contactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All, 
                    Formatting = Formatting.Indented 
                })!;
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
    public IContactModel UpdateOneCOntact(Func<IContactModel, bool> predicate)
    {
        try
        {
            IContactModel contact = _contactList.FirstOrDefault(predicate)!;
            //SKRIV IN FNKTIONALITET FÖR ATT UPPDATERA
            return contact;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    //method: DELETE one contact - based on e-mail
    public bool DeleteContact(Func<IContactModel, bool> predicate)
    {
        try
        {
            IContactModel contact = _contactList.FirstOrDefault(predicate)!;
            //SKRIV IN FNKTIONALITET FÖR ATT RADERA BASERAT PÅ EMAIL
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
