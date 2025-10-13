using AddressBook.Core.Models;

namespace AddressBook.Core.Services
{
    public static class DeleteContactConsole
    {
        // Försöker ta bort en kontakt genom att matcha e-post (case-insensitive).
        // Returnerar true om borttagen, annars false.
        public static bool TryDeleteByEmail(List<Contact> contacts, string emailToFind)
        {
            if (string.IsNullOrWhiteSpace(emailToFind))
                return false;

            var index = contacts.FindIndex(c =>
                c.Email.Equals(emailToFind, StringComparison.OrdinalIgnoreCase));

            if (index == -1)
                return false;

            contacts.RemoveAt(index);
            return true;
        }

        // Interaktivt flöde i konsolen: fråga efter e-post, visa enkel bekräftelse och ta bort.
        // Returnerar true om något togs bort.
        public static bool RunInteractive(List<Contact> contacts)
        {
            Console.Write("Write a email to remove: ");
            var email = Console.ReadLine() ?? "";

            // Hitta kontakt för att få lite “feedback” innan vi tar bort
            var contact = contacts.Find(c =>
                c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (contact is null)
            {
                Console.WriteLine("No contact found with this email address. Abort.");
                return false;
            }

            Console.WriteLine($"Found: {contact.Name} ({contact.Email})");
            Console.Write("Are you sure you want to remove this contact? (y/n): ");
            var confirm = (Console.ReadLine() ?? "").Trim().ToLower();

            if (confirm == "y")
            {
                return TryDeleteByEmail(contacts, email);
            }

            Console.WriteLine("Abort. No contact was removed.");
            return false;
        }
    }
}