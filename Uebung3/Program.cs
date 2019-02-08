using System;

namespace Uebung3
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine();

            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine();

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(j);
                }
                Console.WriteLine();
            }
            */

            /*
            int x = 0;
            int y = 0;
            do
            {
                Console.WriteLine("Hallo");
                x += 2;
                x += 1;
            } while (x <= 10 && y <= 5);
            */

            dynamic[] list = { 10, 5, 3, 1, 0 };
            for (int i = 0; i < list.Length - 1; i++)
            {
                Console.WriteLine(list[i]);
            }

            foreach(dynamic num in list)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
