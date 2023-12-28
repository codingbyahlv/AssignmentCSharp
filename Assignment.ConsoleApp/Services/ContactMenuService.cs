using Assignment.ConsoleApp.Interfaces;
using Assignment.Shared.Interfaces;
using Assignment.Shared.Models;
using Assignment.Shared.Respository;

namespace Assignment.ConsoleApp.Services;

public class ContactMenuService(ContactRepository contactRepository) : IContactMenuService
{
    private readonly ContactRepository _contactRepository = contactRepository;
    private IEnumerable<IContactModel> _contacts = new List<IContactModel>();

    //method: show all contacts
    public void ShowAllContacts()
    {
        Console.Clear();
        Console.WriteLine("\n---------------------------------------\n");

        _contacts = _contactRepository.GetAllContacts();

        if (_contacts.Any())
        {
            for (int i = 0; i < _contacts.Count(); i++)
            {
                Console.WriteLine($"[{i + 1}] {_contacts.ElementAt(i).FirstName} {_contacts.ElementAt(i).LastName}");
            }
        }

        Console.WriteLine("\n---------------------------------------\n");
        Console.Write("Välj kontaktens position för att se mer/redigera: ");
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
        if (result) 
        { 
            Console.WriteLine("\nKontakt tillagd!");
            Console.WriteLine("\nTryck ENTER för att återgå till huvudmenyn...");
        }
        else Console.WriteLine("\nNågot gick fel. Försök igen");
    }


    //method: show one contact based on index position
    public void ShowOneContact(string input)
    {
        Console.Clear();

        if(int.TryParse(input, out int position))
        {
            position--;
            if(position < _contacts.Count())
            {
                IContactModel contact = _contactRepository.GetOneContact(c => c.Id.Equals(_contacts.ElementAt(position).Id));
                if (contact != null)
                {

                    Console.WriteLine("\n---------------------------------------\n");
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"{contact.Address}");
                    Console.WriteLine($"{contact.ZipCode} {contact.City}");
                    Console.WriteLine($"{contact.Email}");
                    Console.WriteLine($"{contact.PhoneNumber}");
                    Console.WriteLine("\n---------------------------------------\n");
                    Console.WriteLine("[U] Uppdatera kontakt");
                    Console.WriteLine("[R] Radera kontakt");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.U:  
                            UpdateContact(contact.Id);
                            break;
                        case ConsoleKey.R:
                            DeleteContact(contact.Id);
                            break;
                        default:
                            Console.WriteLine("\nFel knapp");
                            break;
                    }
                }
                else Console.WriteLine("\nIngen kontakt hittas");
            }
            else Console.WriteLine("\nDu har valt en felaktig siffra");
        }
    }


    //method: update contact based on Id
    public void UpdateContact(Guid Id)
    {
        Console.WriteLine("\nSkriv in nya uppgifter");
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
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            Email = Email,
            Address = Address,
            ZipCode = ZipCode,
            City = City
        };

        bool result = _contactRepository.UpdateOneContact(c => c.Id.Equals(Id), updatedContact);
        if (result)
        {
            Console.WriteLine("\nKontakten uppdaterad!");
            Console.WriteLine("\nTryck ENTER för att återgå till huvudmenyn...");
        }
        else Console.WriteLine("\nNågot gick fel. Försök igen");
    }


    //method: delete contact based on Id
    public void DeleteContact(Guid id)
    {
        bool result = _contactRepository.DeleteOneContact(x => x.Id.Equals(id));
        if (result)
        {
            Console.WriteLine("\nKontakt raderad!");
            Console.WriteLine("\nTryck ENTER för att återgå till huvudmenyn...");
        }
        else Console.WriteLine("\nNågot gick fel. Försök igen");  
    }
}
