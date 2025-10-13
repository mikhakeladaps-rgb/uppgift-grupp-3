using System.Diagnostics.Contracts;
using AddressBook.Core.Models;

namespace AddressBook.Core.Services
{
    public class ContactManager
    {
        private readonly FileService _fileService;

        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public Contact GetContactById(int id) => Contacts.FirstOrDefault(c => c.Id == id)!;
         public ContactManager()
         {
             LoadContacts();
         }

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

         public void SaveContacts()
        {
            // bara spara till fil
            _fileService.Save(Contacts);
         }
        public void AddContact(Contact contact)
        {
            // lägg till kontakt i listan
            Contacts.Add(contact);
            _fileService.Save(Contacts);
         }

         public void DeleteContact(Contact contact)
        {
            // ta bort kontakt från listan
            Contacts.Remove(contact);
            _fileService.Save(Contacts);
         }

        // söka
        public List<Contact> SearchContacts(string term)
        {
            var contacts = _fileService.Load();
            if (string.IsNullOrWhiteSpace(term))
                return [.. contacts];
            term = term.Trim();
            return [.. contacts.Where(c =>
            (c.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.City?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.Email?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.PhoneNumber?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.Street?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (c.PostalCode?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false)
        )];
        }
    }
}
    // i denna klass sker anrop till FileService för att skriva och läsa textfil med "data"