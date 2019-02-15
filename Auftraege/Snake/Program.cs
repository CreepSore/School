using Snake.Rendering;
using System;

namespace Snake
{
    class Program
    {
        public const int WIN_WIDTH = 60;
        public const int WIN_HEIGHT = 30;

        static void Main(string[] args)
        {
            InitConsole();

            Snake s = new Snake();
            s.Start();

            Console.ReadKey(true);
        }

        public static void InitConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.CursorVisible = false;

            Console.SetWindowSize(WIN_WIDTH, WIN_HEIGHT);
            Console.SetBufferSize(WIN_WIDTH, WIN_HEIGHT);
            Console.SetWindowSize(WIN_WIDTH, WIN_HEIGHT);
        }
    }
}
