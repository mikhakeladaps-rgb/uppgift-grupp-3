public static class SearchContact
{
    // Enkel interaktiv sökning i konsolen. Använder ContactManager.SearchContacts.
    public static void RunInteractive(ContactManager manager)
    {
        Console.Write("Search (for example 'elin' or 'Malmö'): ");
        var term = Console.ReadLine() ?? "";

        var results = manager.SearchContacts(term);

        if (results.Count == 0)
        {
            Console.WriteLine("No matches.");
            return;
        }

        Console.WriteLine($"Matches ({results.Count}):");
        foreach (var c in results)
            Console.WriteLine($"{c.Name} | {c.Email} | {c.Phone} | {c.Street}, {c.PostalCode} {c.City}");
    }
}
