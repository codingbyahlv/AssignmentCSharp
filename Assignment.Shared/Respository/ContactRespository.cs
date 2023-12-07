using Assignment.Shared.Interfaces;
using System.Diagnostics;

namespace Assignment.Shared.Respository;

internal class ContactRespository : IContactRepository
{
    //instantiate: the reusable list
    private List<IContactModel> _contactList = new List<IContactModel>();


    //method: CREATE person to list
    public bool AddContactToList(IContactModel contact)
    {
        try
        {
            //SKRIV IN FUNKTIONALITET FÖR ATT LÄGGA TILL
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    //method: READ all contacts
    public IEnumerable<IContactModel> GetAllContacts()
    {
        //SKRIV IN FUNKTIONALITET
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



    //method: DELETE one contact - based on e-mail
    public bool DeleteContact(string Email)
    {
        try
        {
            //SKRIV IN FNKTIONALITET FÖR ATT RADERA BASERAT PÅ EMAIL
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
