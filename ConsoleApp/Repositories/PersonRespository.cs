using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System.Diagnostics;

namespace ConsoleApp.Repositories;

public class PersonRespository : IPersonRespository
{
    //instantiate: the reusable list
    private List<Person> _personsList = [];


    //method: CREATE person to list
    public bool AddPersonToList(Person person)
    {
        try
        {
            //SKRIV IN FUNKTIONALITET FÖR ATT LÄGGA TILL
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    //method: READ all persons
    public IEnumerable<Person> GetAllPersons()
    {
        return _personsList;
    }


    //method: READ one person - based on firstname
    public IPerson GetOnePerson(string FirstName)
    {
        IPerson person = _personsList.FirstOrDefault(p => p.FirstName == FirstName)!;
        return person;
    }


    //method: DELETE one person - based on e-mail
    public bool DeletePerson(string Email)
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
