using AddressBook.Core.Models;

public class ContactManager
{
    private readonly FileService _fileService;

    public ContactManager() : this(new FileService()) { }

    public ContactManager(FileService fileService)
    {
        _fileService = fileService;
        Console.WriteLine("This is from ContactManager");
    }
    // spara
    public void AddContact(Contact contact)
    {
        if (contact is null) return;
        var contacts = _fileService.Load();
        contacts.Add(contact);
        _fileService.Save(contacts);
        Console.WriteLine($"Contact {contact.Name} has been added");
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
        var contacts = _fileService.Load();
        bool changed = UpdateContactConsole.RunInteractive(contacts);
        if (changed) _fileService.Save(contacts);
    }

    public bool UpdateContactByEmail(string emailToFind, Contact updated)
    {
        var contacts = _fileService.Load();
        bool ok = UpdateContactConsole.TryUpdateByEmail(contacts, emailToFind, updated);
        if (ok)
        {
            _fileService.Save(contacts);
            Console.WriteLine($"Contact with email: {emailToFind} has been updated.");
        }
        return ok;
    }
    // ta bort
    public void DeleteContactFromConsole()
    {
        var contacts = _fileService.Load();
        bool deleted = DeleteContactConsole.RunInteractive(contacts);
        if (deleted)
        {
            _fileService.Save(contacts);
            Console.WriteLine("Contact was removed and the list was updated.");
        }
    }

    public bool DeleteContactByEmail(string emailToFind)
    {
        var contacts = _fileService.Load();
        bool ok = DeleteContactConsole.TryDeleteByEmail(contacts, emailToFind);
        if (ok)
        {
            _fileService.Save(contacts);
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
        var contacts = _fileService.Load();
        if (string.IsNullOrWhiteSpace(term))
            return [.. contacts];
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
        var contacts = _fileService.Load();
        Console.WriteLine("List of all contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Name}, {contact.Email}, {contact.PhoneNumber}");
        }
    }
}
    // i denna klass sker anrop till FileService för att skriva och läsa textfil med "data"