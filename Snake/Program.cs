﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public const int WIN_WIDTH = 40;
        public const int WIN_HEIGHT = 20;

        static void Main(string[] args)
        {
            InitConsole();
            Snake s = new Snake();
            s.Start();

            Console.ReadKey(true);
        }

        static void InitConsole()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetWindowSize(WIN_WIDTH, WIN_HEIGHT);
            Console.SetBufferSize(WIN_WIDTH, WIN_HEIGHT);
            Console.SetWindowSize(WIN_WIDTH, WIN_HEIGHT);
        }
    }
}
