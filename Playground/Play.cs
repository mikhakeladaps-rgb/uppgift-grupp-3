using AddressBook.Core;

namespace AddressBook.CLI
{
    public class Play
    {
        static void Main(string[] args)
        {
            Dummy d = new Dummy();
            d.Name = "Hello, World from Playground!";

            Console.WriteLine(d.Name);
        }
    }
}
