using ConsoleApp.Models;

namespace ConsoleApp.Interfaces
{
    public interface IPersonRespository
    {
        bool AddPersonToList(Person person);
        bool DeletePerson(string Email);
        IEnumerable<Person> GetAllPersons();
        IPerson GetOnePerson(string FirstName);
    }
}