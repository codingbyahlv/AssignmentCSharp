using Assignment.ConsoleApp.Interfaces;
using Assignment.Shared.Interfaces;
using Assignment.Shared.Models;
using Assignment.Shared.Respository;

namespace Assignment.ConsoleApp.Services;

public class ContactMenuService(ContactRespository contactRepository) : IContactMenuService
{
    private readonly ContactRespository _contactRepository = contactRepository;

    //method: show all contacts
    public void ShowAllContacts()
    {
        Console.Clear();
        Console.WriteLine("\n---------------------------------------\n");

        foreach (IContactModel contact in _contactRepository.GetAllContacts())
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
        }

        Console.WriteLine("\n---------------------------------------\n");
        Console.Write("Skriv förnamnet på den du vill se mer om: ");
        string input = Console.ReadLine()!;

        if(input != null ) ShowOneContact(input);
    }


    //method: add new contact
    public void AddNewContact()
    {
        Console.Clear();
        Console.Write("Förnamn: ");
        string FirstName = Console.ReadLine()!;
        Console.Write("Efternamn: ");
        string LastName = Console.ReadLine()!;
        Console.Write("Telefonnummer: ");
        string PhoneNumber = Console.ReadLine()!;
        Console.Write("E-post: ");
        string Email = Console.ReadLine()!;
        Console.Write("Adress: ");
        string Address = Console.ReadLine()!;
        Console.Write("Postnummer: ");
        string ZipCode = Console.ReadLine()!;
        Console.Write("Ort: ");
        string City = Console.ReadLine()!;

        IContactModel contact = new ContactModel
        { 
            FirstName = FirstName, 
            LastName = LastName, 
            PhoneNumber = PhoneNumber, 
            Email = Email,
            Address = Address, 
            ZipCode = ZipCode, 
            City = City 
        };

        bool result = _contactRepository.AddContactToList(contact);

        //LÄGG IN RESPONSHANTERING
    }

    //method: show one contact based on firstname
    public void ShowOneContact(string input)
    {
        Console.Clear();
        IContactModel contact = _contactRepository.GetOneContact(c => c.FirstName.Equals(input, StringComparison.CurrentCultureIgnoreCase));
        
        if(contact != null)
        {
            Console.WriteLine("\n---------------------------------------\n");
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{contact.Address}");
            Console.WriteLine($"{contact.ZipCode} {contact.City}");
            Console.WriteLine($"{contact.Email}");
            Console.WriteLine($"{contact.PhoneNumber}");
        } 
        else
        {
            Console.WriteLine("\n---------------------------------------\n");
            Console.WriteLine("Ingen kontakt hittas");
        }
    }
}
