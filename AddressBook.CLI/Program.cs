using AddressBook.Core.Services;
using AddressBook.Core.Models;
namespace AddressBook.CLI
{
    public class Program
    {
        private static ContactManager contactManager = new ContactManager();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                int choice = UIHandler.ShowMenu();


                switch (choice)
                {
                    case 1:
                        ShowAllContacts();
                        break;

                    case 2:
                        SearchContacts();
                        break;

                    case 3:
                        AddContact();
                        break;

                    case 4:
                        RemoveContact();
                        break;

                    case 5:
                        UpdateContact();
                        break;

                    case 6:
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
           UIHandler.ShowContacts(contactManager.Contacts);
        }
        static void SearchContacts()
        {
            string term = UIHandler.Ask("Ange sökterm: ");
            var results = contactManager.SearchContacts(term);
            UIHandler.ShowContacts(results);
        }

        static void AddContact()
        {
            UIHandler.ShowTitle("Lägg till kontakt");

            int nextId = Enumerable.Range(1, int.MaxValue)
            .Except(contactManager.Contacts.Select(c => c.Id))
            .First();

            var contact = new Contact
            {
                Id = nextId,
                Name = UIHandler.Ask("Namn: "),
                Street = UIHandler.Ask("Gatuadress: "),
                PostalCode = UIHandler.Ask("Postnummer: "),
                City = UIHandler.Ask("Stad: "),
                PhoneNumber = UIHandler.Ask("Telefonnummer: "),
                Email = UIHandler.Ask("Email: "),
            };
            contactManager.AddContact(contact);
            UIHandler.Print($"Kontakt {contact.Name} tillagd.");
            UIHandler.Wait();
        }

        static void RemoveContact()
        {
            int id = UIHandler.AskForId("Ange ID för kontakten som ska tas bort (0 för att avbryta): ");
            if (id == 0)
            {
                UIHandler.Print("Åtgärden avbröts.");
                UIHandler.Wait();
                return;
            }

            var contact = contactManager.GetContactById(id);
            if (contact == null)
            {
                UIHandler.Print($"Ingen kontakt hittades med ID {id}.");
                UIHandler.Wait();
                return;
            }
            UIHandler.Print($"Du har valt att ta bort kontakten:");
            UIHandler.ShowContact(contact);
            bool confirm = UIHandler.Confirm("Är du säker på att du vill ta bort denna kontakt? (j/n): ");
            if (!confirm)
            {
                UIHandler.Print("Åtgärden avbröts.");
                UIHandler.Wait();
                return;
            }
            contactManager.DeleteContact(contact);
            UIHandler.Print($"Kontakt {contact.Name} borttagen.");
            UIHandler.Wait();
        }
        static void UpdateContact()
        {
            int id = UIHandler.AskForId("Ange ID för kontakten som ska uppdateras (0 för att avbryta): ");
            if (id == 0)
            {
                UIHandler.Print("Åtgärden avbröts.");
                UIHandler.Wait();
                return;
            }

            var contact = contactManager.GetContactById(id);
            if (contact == null)
            {
                UIHandler.Print($"Ingen kontakt hittades med ID {id}.");
                UIHandler.Wait();
                return;
            }

            UIHandler.ShowContact(contact);

            UIHandler.PrintLine();

            UIHandler.Print("Lämna fält tomt för att behålla nuvarande värde.");
            string name = UIHandler.Ask($"Namn ({contact.Name})");
            string street = UIHandler.Ask($"Gatuadress ({contact.Street})");
            string postalCode = UIHandler.Ask($"Postnummer ({contact.PostalCode})");
            string city = UIHandler.Ask($"Stad ({contact.City})");
            string phoneNumber = UIHandler.Ask($"Telefonnummer ({contact.PhoneNumber})");
            string email = UIHandler.Ask($"Email ({contact.Email})");

            if (!string.IsNullOrWhiteSpace(name)) contact.Name = name;
            if (!string.IsNullOrWhiteSpace(street)) contact.Street = street;
            if (!string.IsNullOrWhiteSpace(postalCode)) contact.PostalCode = postalCode;
            if (!string.IsNullOrWhiteSpace(city)) contact.City = city;
            if (!string.IsNullOrWhiteSpace(phoneNumber)) contact.PhoneNumber = phoneNumber;
            if (!string.IsNullOrWhiteSpace(email)) contact.Email = email;

            contactManager.SaveContacts();
            UIHandler.Print($"Kontakt {contact.Name} uppdaterad.");
            UIHandler.Wait();
        }
    }
}