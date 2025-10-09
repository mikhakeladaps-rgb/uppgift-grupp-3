using AddressBook.Core;
using AddressBook.Core.Services;

namespace AddressBook.CLI
{
    public class Play
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();
            contactManager.ShowAllContacts();
        }
    }
}
