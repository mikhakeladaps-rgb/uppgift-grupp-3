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