public static class AddContactConsole
{
    public static ContactList CreateContactFromConsole()
    {
        Console.WriteLine("Add a new contact");
        string GetInput(string fieldName)
        {
            string? input;
            do
            {
                Console.Write($"{fieldName}: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine($"{fieldName} can't be empty!");
            } while (string.IsNullOrWhiteSpace(input));
            return input.Trim();

        }
            var contact = new ContactList
        {
            Name = GetInput("Name"),
            Street = GetInput("Street"),
            PostalCode = GetInput("PostalCode"),
            City = GetInput("City"),
            Phone = GetInput("Phone"),
            Email = GetInput("Email")
        };
        return contact;
    }
}

    