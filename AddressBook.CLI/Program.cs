using AddressBook.Core;

namespace AddressBook.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                UIHandler.Clear();
                UIHandler.ShowMenu();
                string choice = UIHandler.GetInput("");

                switch (choice)
                {
                    case "1":
                        ShowAllContacts();
                        break;

                    case "2":
                        SearchContacts();
                        break;

                    case "3":
                        AddContact();
                        break;

                    case "4":
                        RemoveContact();
                        break;

                    case "5":
                        running = false;
                        UIHandler.Print("Programmet avslutas...");
                        break;

                    default:
                        UIHandler.Print("Ogiltigt val, försök igen.");
                        UIHandler.Wait();
                        break;
                }
            }
        }


        static void ShowAllContacts()
        {
            UIHandler.Clear();
            UIHandler.ShowTitle("Alla kontakter");
            UIHandler.Print("(Här ska kontakter listas sen)");
            UIHandler.Wait();
        }

        static void SearchContacts()
        {
            UIHandler.Clear();
            UIHandler.ShowTitle("Sök kontakt");
            string query = UIHandler.GetInput("Ange namn att söka: ");
            UIHandler.Print($"(Här ska vi söka efter '{query}')");
            UIHandler.Wait();
        }

        static void AddContact()
        {
            UIHandler.Clear();
            UIHandler.ShowTitle("Lägg till kontakt");
            string name = UIHandler.GetInput("Namn: ");
            string phone = UIHandler.GetInput("Telefon: ");
            string email = UIHandler.GetInput("E-post: ");
            UIHandler.Print($"(Här ska vi spara {name}, {phone}, {email})");
            UIHandler.Wait();
        }

        static void RemoveContact()
        {
            UIHandler.Clear();
            UIHandler.ShowTitle("Ta bort kontakt");
            string name = UIHandler.GetInput("Ange namn att ta bort: ");
            UIHandler.Print($"(Här ska vi ta bort '{name}')");
            UIHandler.Wait();
        }
    }
}