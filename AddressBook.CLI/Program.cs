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

            // Visa alla kontakter
            manager.ShowAllContacts();
        }
    }
}
