using logiclib;

namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dummy d = new Dummy();
            d.name = "Hello, World!";

            Console.WriteLine(d.name);
        }
    }
}
