using System;

namespace Uebung1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No arguments specified!");
                Console.ReadKey(true);
                Environment.Exit(0);
            }

            string output = "Ungültige Sprache";
            switch (args[0])
            {
                case "de":
                    output = "Hallo Welt!!";
                    break;

                case "en":
                    output = "Hello World!!";
                    break;
            }
            Console.WriteLine(output);
        }
    }
}
