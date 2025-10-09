using AddressBook.Core.Models;

public class ContactManager	// hanterar en "lista" med Contact
{
    public ContactManager()
    {
        Console.WriteLine("This is from ContactManager");
        contacts = PersistenceHelper.LoadContacts();
    }

    // ska innehålla en List<Contact> som vi arbetar med
    private List<Contact> contacts = new List<Contact>();

    // spara
    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
        Console.WriteLine($"Contact {contact.Name} has been added");
        PersistenceHelper.SaveContacts(contacts);
    }
    // skapa kontakt i konsollen
    public void AddContactFromConsole()
    {
        var contact = AddContactConsole.CreateContactFromConsole();
        AddContact(contact);
    }
    // uppdatera
    public void UpdateContactFromConsole()
    {
        bool changed = UpdateContactConsole.RunInteractive(contacts);
        if (changed)
        {
            PersistenceHelper.SaveContacts(contacts);
        }
    }

    public bool UpdateContactByEmail(string emailToFind, Contact updated)
    {
        bool ok = UpdateContactConsole.TryUpdateByEmail(contacts, emailToFind, updated);
        if (ok)
        {
            PersistenceHelper.SaveContacts(contacts);
            Console.WriteLine($"Contact with email: {emailToFind} has been updated.");
        }
        return ok;
    }
    // ta bort
    public void DeleteContactFromConsole()
    {
        bool deleted = DeleteContactConsole.RunInteractive(contacts);
        if (deleted)
        {
            PersistenceHelper.SaveContacts(contacts); 
            Console.WriteLine("Contact was removed and the list was updated.");
        }
    }

    public bool DeleteContactByEmail(string emailToFind)
    {
        bool ok = DeleteContactConsole.TryDeleteByEmail(contacts, emailToFind);
        if (ok)
        {
            PersistenceHelper.SaveContacts(contacts);
            Console.WriteLine($"Contact with email: {emailToFind} has been removed.");
        }
        else
        {
            Console.WriteLine($"No contact found with this email address: {emailToFind}");
        }
        return ok;
    }
    // söka
    public List<Contact> SearchContacts(string term)
    {
        term = term.Trim();
        return [.. contacts.Where(c =>
            (c.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.City?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.Email?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.PhoneNumber?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.Street?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.PostalCode?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false)
        )];
    }
    //hämta ut alla kontakter
    public void ShowAllContacts()
    {
        Console.WriteLine("List of all contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Name}, {contact.Email}, {contact.PhoneNumber}");
        }
    }
}
    // i denna klass sker anrop till FileService för att skriva och läsa textfil med "data"