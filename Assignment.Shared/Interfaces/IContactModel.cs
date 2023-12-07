namespace Assignment.Shared.Interfaces;

public interface IContactModel
{   
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
    string Address { get; set; }
    string ZipCode { get; set; }
    string City { get; set; }
}
