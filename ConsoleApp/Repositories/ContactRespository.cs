using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System.Diagnostics;

namespace ConsoleApp.Repositories;

public class ContactRespository : IContactRespository
{
    //instantiate: the reusable list
    private List<Contact> _contactList = new List<Contact>();


    //method: CREATE person to list
    public bool AddContactToList(Contact contact)
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
    public IEnumerable<Contact> GetAllContacts()
    {
        //SKRIV IN FUNKTIONALITET
        return _contactList;
    }


    //method: READ one contact - based on firstname
    //public IContact GetOneContact(string FirstName)
    //{
    //    IContact contact = _contactList.FirstOrDefault(c => c.FirstName == FirstName)!;
    //    return contact;
    //}
    public IContact GetOneContact(Func<IContact, bool> predicate)
    {
        IContact contact = _contactList.FirstOrDefault(predicate)!;
        if(contact != null) 
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
