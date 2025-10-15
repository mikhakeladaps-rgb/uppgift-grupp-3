namespace AddressBook.Core.Models;

// Modell för en kontakt
public class Contact
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}