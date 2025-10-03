// Detta innehåller allting som har med utskrigt att göra i konsollen
// Alltså vi skapar en klass här som hanterar all typ av COonsole.Write... och Console.WriteLine
// T.ex. en funktion i klassen som skriver ut hela menyn
// Vi gör detta till en statiskt klass för enkel åtkomst

public static class UIHandler
{
    public static void ShowMenu()
    {
        Console.WriteLine($"Meny text här...");
    }
}