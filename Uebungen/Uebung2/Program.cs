using System;
using System.Text;

namespace Uebung2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                ThrowErrorAndExit("Invalid Arguments!");
            }

            string text = args[0];
            int count;

            if (!Int32.TryParse(args[1], out count))
            {
                if(!Int32.TryParse(args[0], out count))
                {
                    ThrowErrorAndExit("No Number Argument found!");
                }
                text = args[1];
            }

            text = text.Replace("{nl}", "\n");

            Console.WriteLine(RepeatString(text, count));
            Console.ReadKey(true);
        }

        public static void ThrowErrorAndExit(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        public static string RepeatString(string str, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }
    }
}
