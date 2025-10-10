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
        Console.WriteLine("5. Avsluta");
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

    public static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static void Wait()
    {
        Console.WriteLine();
        Console.WriteLine("Tryck på enter för att fortsätta...");
        Console.ReadLine();
    }

    public static void Clear()
    {
        Console.Clear();
    }
}