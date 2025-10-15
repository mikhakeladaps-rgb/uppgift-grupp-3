using System.Diagnostics.Contracts;
using AddressBook.Core.Models;

namespace AddressBook.Core.Services
{
    // Hanterar kontakter: läs, skriv, lägg till, ta bort, sök
    public class ContactManager
    {
        // instans av filhantering
        private readonly FileService _fileService = new FileService();

        // lista av kontakter
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        // hämta kontakt via Id
        public Contact GetContactById(int id) => Contacts.FirstOrDefault(c => c.Id == id)!;


        // konstruktor
        public ContactManager()
        {
            LoadContacts();
        }

        // ladda kontakter från fil
        public void LoadContacts()
        {
            // bara läsa från fil och sortera på Id
            var loaded = _fileService.Load();
            var list = (loaded ?? new List<Contact>()).OrderBy(x => x.Id);
            Contacts.Clear();
            foreach (var contact in list)
            {
                Contacts.Add(contact);
            }

        }

        // spara kontakter till fil
        public void SaveContacts()
        {
            // bara spara till fil
            _fileService.Save(Contacts);
        }

        // lägg till kontakt
        public void AddContact(Contact contact)
        {
            // lägg till kontakt i listan
            Contacts.Add(contact);
            _fileService.Save(Contacts);
        }

        // ta bort kontakt
        public void DeleteContact(Contact contact)
        {
            // ta bort kontakt från listan
            Contacts.Remove(contact);
            _fileService.Save(Contacts);
        }

        // sök kontakter
        public List<Contact> SearchContacts(string term)
        {



            term = term.Trim();
            List<Contact> results = Contacts.Where(c =>
            (c.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.City?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.Email?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.PhoneNumber?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.Street?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.PostalCode?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false)
        ).ToList();

            return results;
        }
    }
}