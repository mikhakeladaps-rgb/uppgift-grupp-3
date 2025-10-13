using System;
using AddressBook.Core.Models;

public static class UIHandler
{
    public static void ShowMenu()
    {
        Console.WriteLine("=== KONTAKTER ===");
        Console.WriteLine("1. Visa alla kontakter");
        Console.WriteLine("2. Sök kontakter");
        Console.WriteLine("3. Lägg till kontakt");
        Console.WriteLine("4. Ta bort kontakt");
        Console.WriteLine("5. Uppdatera kontakt");
        Console.WriteLine("6. Avsluta");
        Console.Write("Välj ett alternativ: ");
    }

    public static void ShowTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine("--- " + title + " ---");
    }

    public static void Print(string text)
    {
        Console.WriteLine(text);
    }

    public static void PrintLine()
    {
        Console.WriteLine();
    }
    public static void Wait()
    {
        Console.WriteLine();
        Console.WriteLine("Tryck på enter för att fortsätta...");
        Console.ReadLine();
        Console.Clear();
    }

    public static void Clear()
    {
        Console.Clear();
    }

    public static void ShowContact(Contact contact)
    {
        Console.WriteLine("Kontaktinformation:");
        Console.WriteLine($"Id: {contact.Id}");
        Console.WriteLine($"Namn: {contact.Name}");
        Console.WriteLine($"Adress: {contact.Street}, {contact.PostalCode}, {contact.City}");
        Console.WriteLine($"Telefon: {contact.PhoneNumber}");
        Console.WriteLine($"E-post: {contact.Email}");
    }

    public static void ShowContacts(List<Contact> contacts)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("Inga kontakter hittades.");
            return;
        }

        Console.WriteLine("Kontakter:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Id: {contact.Id}");
            Console.WriteLine($"Namn: {contact.Name}");
            Console.WriteLine($"Adress: {contact.Street}, {contact.PostalCode}, {contact.City}");
            Console.WriteLine($"Telefon: {contact.PhoneNumber}");
            Console.WriteLine($"E-post: {contact.Email}");
            Console.WriteLine("-------------------------------------------");
        }
    }

    public static int GetId()
    {
        Console.Write("Ange kontaktens Id: ");

        if (int.TryParse(Console.ReadLine(), out int id) && id > 0)
        {
            return id;
        }
        Console.WriteLine("Ogiltigt val. Vänligen ange ett nummer.");
        return 0;
    }

    public static string Ask(string question)
    {
        Console.Write(question + ": ");
        return Console.ReadLine() ?? string.Empty;

    }
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
