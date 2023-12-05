namespace ConsoleApp.Interfaces;

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; } 
    string PhoneNumber { get; set; }
    string Email { get; set; }
    string Address {  get; set; }
    string ZipCode { get; set; }
    string City {  get; set; }
}
