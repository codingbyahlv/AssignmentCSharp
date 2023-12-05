using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System.Diagnostics;

namespace ConsoleApp.Repositories;

public class PersonRespository
{
    //instantiate: the reusable list
    private List<Person> _personsList = [];

    //method: CREATE person to list
    public bool AddPersonToList(Person person)
    {
        try
        {
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


    //method: READ one person
    public IPerson GetOnePerson(string FirstName)
    {
        IPerson person = _personsList.FirstOrDefault(p => p.FirstName == FirstName)!;
        return person;
    }

    //method: DELETE one person
    public bool DeletePerson(string Email)
    {
        try
        {
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
    }
}
