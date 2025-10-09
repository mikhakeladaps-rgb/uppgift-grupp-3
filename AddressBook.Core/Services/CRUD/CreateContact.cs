using AddressBook.Core.Models;

public static class AddContactConsole
{
    public static Contact CreateContactFromConsole()
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
            var contact = new Contact
        {
            Name = GetInput("Name"),
            Street = GetInput("Street"),
            PostalCode = GetInput("PostalCode"),
            City = GetInput("City"),
            PhoneNumber = GetInput("PhoneNumber"),
            Email = GetInput("Email")
        };
        return contact;
    }
}

    