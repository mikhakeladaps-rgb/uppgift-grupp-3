using AddressBook.Core;

namespace AddressBook.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dummy d = new Dummy();
            d.Name = "Hello, World from CLI!";

            Console.WriteLine(d.Name);

            // skriv ut meny
            UIHandler.ShowMenu();

            var manager = new ContactManager();
            // Lägg till några kontakter
            manager.AddContactFromConsole();

            //Uppdatera en kontakt från konsollen
            manager.UpdateContactFromConsole();
            //Uppdatera kontakt från "kod"
            var updatedContact = new ContactList
            {
                Name = "Elin Nyström",          
                Email = "elin@example.com",      
                Phone = "070-999 88 77",         
                Street = "Storgatan 5",
                City = "Malmö",
                PostalCode = "21111"
            };
            manager.UpdateContactByEmail("Elin@example.com", updatedContact);
            // Visa alla kontakter
            manager.ShowAllContacts();
        }
    }
}
