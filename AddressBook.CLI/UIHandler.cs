using System;
using AddressBook.Core.Models;

// Hanterar all användarinteraktion via konsolen
public static class UIHandler
{
    // Metod för att visa huvudmenyn och validera användarens val
    public static int ShowMenu()
    {
        Console.WriteLine("=== KONTAKTER ===");
        Console.WriteLine("1. Visa alla kontakter");
        Console.WriteLine("2. Sök kontakter");
        Console.WriteLine("3. Lägg till kontakt");
        Console.WriteLine("4. Ta bort kontakt");
        Console.WriteLine("5. Uppdatera kontakt");
        Console.WriteLine("6. Avsluta");
        Console.Write("Välj ett alternativ: ");
        return ValidateMenuChoice(1, 6);
    }

    // Validera menyval
    private static int ValidateMenuChoice(int min, int max)
    {
        while (true)
        {
         string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ogiltigt val. Vänligen ange ett nummer mellan {min} och {max}: ");
            Console.ResetColor();
            return 0;
        }
    }

    // Metod för att visa en titel
    public static void ShowTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine("--- " + title + " ---");
    }

    // Metod för att skriva ut text
    public static void Print(string text)
    {
        Console.WriteLine(text);
    }

    // Metod för att skriva ut en tom rad
    public static void PrintLine()
    {
        Console.WriteLine();
    }

    // Metod för att vänta på användarens input innan programmet fortsätter
    public static void Wait()
    {
        Console.WriteLine();
        Console.WriteLine("Tryck på enter för att fortsätta...");
        Console.ReadLine();
        Console.Clear();
    }

    // Metod för att rensa konsolen
    public static void Clear()
    {
        Console.Clear();
    }

    // Metod för att visa en kontakt
    public static void ShowContact(Contact contact)
    {
        Console.WriteLine();
        Console.WriteLine("Kontaktinformation:");
        Console.WriteLine($"Id: {contact.Id}");
        Console.WriteLine($"Namn: {contact.Name}");
        Console.WriteLine($"Adress: {contact.Street}, {contact.PostalCode}, {contact.City}");
        Console.WriteLine($"Telefon: {contact.PhoneNumber}");
        Console.WriteLine($"E-post: {contact.Email}");
    }

    // Metod för att visa en lista med kontakter, alla eller sökresultat
    public static void ShowContacts(List<Contact> contacts)
    {
        Console.WriteLine();

        if (contacts.Count == 0)
        {
            Console.WriteLine("Inga kontakter hittades.");
            return;
        }

        Console.WriteLine("Kontakter:");
        Console.WriteLine("-------------------------------------------");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Id: {contact.Id}");
            Console.WriteLine($"Namn: {contact.Name}");
            Console.WriteLine($"Adress: {contact.Street}, {contact.PostalCode}, {contact.City}");
            Console.WriteLine($"Telefon: {contact.PhoneNumber}");
            Console.WriteLine($"E-post: {contact.Email}");
            Console.WriteLine("-------------------------------------------");
        }

        Console.WriteLine();
    }

    // Metod för att fråga användaren om input och returnera svaret
    public static string Ask(string question)
    {
        Console.Write(question + ": ");
        return Console.ReadLine() ?? string.Empty;

    }

    // Metod för att fråga användaren om ett giltigt Id och returnera det
    public static int AskForId(string question)
    {
        Console.Write(question + ": ");
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int id) && id >= 0)
                return id;
            Console.Write("Ogiltigt val. Vänligen ange ett nummer: ");
        }
    }

    // Metod för att bekräfta en åtgärd med ja eller nej
    public static bool Confirm(string question)
    {
        Console.Write(question + " (j/n): ");
        while (true)
        {
            var input = Console.ReadLine()?.ToLower();
            if (input == "j" || input == "ja") return true;
            if (input == "n" || input == "nej") return false;
            Console.Write("Ogiltigt val. Vänligen svara med 'j' eller 'n': ");
        }

    }
}
