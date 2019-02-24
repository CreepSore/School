using System;

namespace Uebung4
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = 0;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(15, 10);
                Console.WriteLine("1. Addition");
                Console.SetCursorPosition(15, 11);
                Console.WriteLine("2. Subtraction");
                Console.SetCursorPosition(15, 12);
                Console.Write("> ");


                string textInput = Console.ReadLine();
                if (!Int32.TryParse(textInput, out input))
                {
                    continue;
                }

                HandleInput(15, 10, input);

                Console.ReadKey(true);
            } while (input != 0);

        }

        private static void HandleInput(int top, int left, int mode)
        {
            Console.Clear();

            Console.SetCursorPosition(left, top);
            Console.Write("Wert 1 = ");
            string textInput1 = Console.ReadLine();

            Console.SetCursorPosition(left, top + 1);
            Console.Write("Wert 2 = ");
            string textInput2 = Console.ReadLine();

            int num0 = 0, num1 = 0;
            if (Int32.TryParse(textInput1, out num0) &&
                Int32.TryParse(textInput2, out num1))
            {
                int result = 0;
                switch(mode)
                {
                    case 1:
                        result = Add(num0, num1);
                        break;

                    case 2:
                        result = Subtract(num0, num1);
                        break;
                }

                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine("Ergebnis: {0}", result);
            }
        }

        private static int Add(int num0, int num1)
        {
            return num0 + num1;
        }

        private static int Subtract(int num0, int num1)
        {
            return num0 - num1;
        }
    }
}
