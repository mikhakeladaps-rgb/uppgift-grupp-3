using AddressBook.Core;
using AddressBook.Core.Models;

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
            var updatedContact = new Contact
            {
                Name = "Elin Nyström",          
                Email = "elin@example.com",      
                PhoneNumber = "070-999 88 77",         
                Street = "Storgatan 5",
                City = "Malmö",
                PostalCode = "21111"
            };
            manager.UpdateContactByEmail("Elin@example.com", updatedContact);

            //Ta bort en kontakt via konsollen
            manager.DeleteContactFromConsole();
            //Ta bort en kontakt fron "kod"
            var removed = manager.DeleteContactByEmail("Elin@example.com");
            Console.WriteLine($"Removed? {removed}");

            //Sök efter kontakt
            SearchContact.RunInteractive(manager);
            
            // Visa alla kontakter
            manager.ShowAllContacts();
        }
    }
}
