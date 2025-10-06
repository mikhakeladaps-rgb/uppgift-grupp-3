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
            manager.AddContact(new ContactList { Name = "Elin Ny", Email = "elin@example.com", Phone = "0701234567" });
            manager.AddContact(new ContactList { Name = "Samuel Samuelsson", Email = "samuel@example.com", Phone = "0737654321" });

            // Visa alla kontakter
            manager.ShowAllContacts();
        }
    }
}
