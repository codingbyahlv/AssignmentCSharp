using Assignment.ConsoleApp.Interfaces;
using Assignment.Shared.Interfaces;
using Assignment.Shared.Models;
using Assignment.Shared.Respository;

namespace Assignment.ConsoleApp.Services;

public class ContactMenuService(ContactRepository contactRepository) : IContactMenuService
{
    private readonly ContactRepository _contactRepository = contactRepository;

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

        if (input != null) ShowOneContact(input);
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
        if (result) Console.WriteLine("\nKontakt tillagd");
        else Console.WriteLine("\nNågot gick fel. Försök igen");
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

            Console.WriteLine();
            Console.WriteLine("[U] Uppdatera kontakt");
            Console.WriteLine("[R] Radera kontakt");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.U:
                    UpdateContact(contact.Email);
                    break;
                case ConsoleKey.R:
                    DeleteContact(contact.Email);
                    break;
                default:
                    Console.WriteLine("\nfel knapp");
                    break;
            }
        }
        else Console.WriteLine("\nIngen kontakt hittas");

    }


    //method: update contact based on current email
    public void UpdateContact(string email)
    {
        Console.WriteLine("Skriv in nya uppgifter");
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

        IContactModel updatedContact = new ContactModel
        {
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            Email = Email,
            Address = Address,
            ZipCode = ZipCode,
            City = City
        };

        bool result = _contactRepository.UpdateOneContact(c => c.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase), updatedContact);
        if (result) Console.WriteLine("\nListan uppdaterad");
        else Console.WriteLine("\nNågot gick fel. Försök igen");
    }


    //method: delete contact based on current email
    public void DeleteContact(string email)
    {
        bool result = _contactRepository.DeleteOneContact(c => c.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        if (result) Console.WriteLine("\nListan uppdaterad");
        else Console.WriteLine("\nNågot gick fel. Försök igen");  
    }
}
