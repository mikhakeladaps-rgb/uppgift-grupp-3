public static class UpdateContactConsole
{
    private static string Prompt(string label, string current)
    {
        Console.Write($"{label} ({current}): ");
        var input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? current : input.Trim();
    }

    public static ContactList BuildUpdated(ContactList existing)
    {
        return new ContactList
        {
            Name = Prompt("Name", existing.Name),
            Street = Prompt("Street", existing.Street),
            PostalCode = Prompt("PostalCode", existing.PostalCode),
            City = Prompt("City", existing.City),
            Phone = Prompt("Phone", existing.Phone),
            Email = Prompt("Email", existing.Email),
        };
    }
    //Hitta kontakt via e-post (case-insensitive)
    private static int FindIndexByEmail(List<ContactList> contacts, string email)
    {
        return contacts.FindIndex(c =>
            c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    // kör hela interaktiva flödet för att uppdatera listan
    // Returnerar true om något uppdaterades.
    public static bool RunInteractive(List<ContactList> contacts)
    {
        Console.Write("Write the email for the contact you want to update: ");
        var email = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("No email was given. Abort.");
            return false;
        }

        var index = FindIndexByEmail(contacts, email);
        if (index == -1)
        {
            Console.WriteLine("No contact found with this email address.");
            return false;
        }

        var existing = contacts[index];

        Console.WriteLine("Leave a empty field and press enter to keep existing value.");
        var updated = BuildUpdated(existing);

        // Om e-post ändras: kolla krockar
        if (!updated.Email.Equals(existing.Email, StringComparison.OrdinalIgnoreCase))
        {
            bool emailTaken = contacts.Any(c =>
                c.Email.Equals(updated.Email, StringComparison.OrdinalIgnoreCase));

            if (emailTaken)
            {
                Console.WriteLine("Another contact was found with this email. Keeping the originals email.");
                updated.Email = existing.Email;
            }
        }

        // Skriv tillbaka i listan
        contacts[index] = updated;

        Console.WriteLine($"Contact {existing.Name} was updated successfully.");
        return true;
    }

    //  enbart logik utan konsol (om du vill uppdatera från koden och inte konsollen)
    public static bool TryUpdateByEmail(List<ContactList> contacts, string emailToFind, ContactList updated)
    {
        var index = FindIndexByEmail(contacts, emailToFind);
        if (index == -1) return false;

        // Om e-post ändras: kolla krockar
        var original = contacts[index];
        if (!updated.Email.Equals(original.Email, StringComparison.OrdinalIgnoreCase))
        {
            bool emailTaken = contacts.Any(c =>
                c.Email.Equals(updated.Email, StringComparison.OrdinalIgnoreCase));
            if (emailTaken)
            {
                updated.Email = original.Email; // tvinga tillbaka för att undvika dublett
            }
        }

        contacts[index] = updated;
        return true;
    }
}