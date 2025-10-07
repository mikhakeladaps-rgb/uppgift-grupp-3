public class ContactManager	// hanterar en "lista" med Contact
{
    public ContactManager()
    {
        Console.WriteLine("This is from ContactManager");
        contacts = PersistenceHelper.LoadContacts();
    }

    // ska innehålla en List<Contact> som vi arbetar med
    private List<ContactList> contacts = new List<ContactList>();

    // spara
    public void AddContact(ContactList contact)
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

    public bool UpdateContactByEmail(string emailToFind, ContactList updated)
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
    // söka
    //hämta ut alla kontakter
    public void ShowAllContacts()
    {
        Console.WriteLine("List of all contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Name}, {contact.Email}, {contact.Phone}");
        }
    }
}
    // i denna klass sker anrop till FileService för att skriva och läsa textfil med "data"