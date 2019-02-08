using System;

namespace Rectangle
{
    class Program
    {
        const char linechar = '+';

        static void Main(string[] args)
        {
            InitConsole(61, 61);

            while (true)
            {
                Console.Clear();
                HandleInput(HandleMenu());
                System.Threading.Thread.Sleep(2000);
            }
        }

        static int HandleMenu()
        {
            int input = -1;
            do
            {
                Console.Clear();
                WriteMiddle("---- Arbeitsauftrag 02 ----", 5);
                WriteMiddle("1. Vertical Line", 6);
                WriteMiddle("2. Horizontal Line", 7);
                WriteMiddle("3. Rectangle", 8);
                WriteMiddle("4. Grid", 9);
                WriteMiddle("5. Exit", 10);

                WriteMiddle("---- Extras ----", 12);
                WriteMiddle("6. Diagonal Line", 13);
                WriteMiddle("7. Cube", 14);


                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.WriteLine(input != 0 ? "" : "Invalid Input!");
                Console.Write("> ");
            } while (!Int32.TryParse(Console.ReadLine(), out input));

            return input;
        }

        static void HandleInput(int input)
        {
            Console.Clear();

            switch (input)
            {
                case 1:
                    DebugVLine();
                    break;

                case 2:
                    DebugHLine();
                    break;

                case 3:
                    DebugRectangle();
                    break;

                case 4:
                    DebugGrid();
                    break;

                // Exit
                case 5:
                    Environment.Exit(0);
                    break;

                case 6:
                    DebugDLine();
                    break;

                case 7:
                    DebugCube();
                    break;
            }
        }

        #region MenuFunctions
        static void DebugVLine()
        {
            string[] textInputs = new string[3];
            int[] parsedNums = new int[textInputs.Length];
            string[] inputNames = { "top", "left", "height" };

            for (int i = 0; i < textInputs.Length; i++)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please input the value for {0}", inputNames[i]);
                    textInputs[i] = Console.ReadLine();
                } while (!Int32.TryParse(textInputs[i], out parsedNums[i]));
            }

            Console.Clear();
            DrawVLine(parsedNums[0], parsedNums[1], parsedNums[2]);
        }

        static void DebugHLine()
        {
            string[] textInputs = new string[3];
            int[] parsedNums = new int[textInputs.Length];
            string[] inputNames = { "top", "left", "width" };

            for (int i = 0; i < textInputs.Length; i++)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please input the value for {0}", inputNames[i]);
                    textInputs[i] = Console.ReadLine();
                } while (!Int32.TryParse(textInputs[i], out parsedNums[i]));
            }

            Console.Clear();
            DrawHLine(parsedNums[0], parsedNums[1], parsedNums[2]);
        }

        static void DebugDLine()
        {
            string[] textInputs = new string[4];
            double[] parsedNums = new double[textInputs.Length];
            string[] inputNames = { "top", "left", "angle", "length" };

            for (int i = 0; i < textInputs.Length; i++)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please input the value for {0}", inputNames[i]);
                    textInputs[i] = Console.ReadLine();
                } while (!double.TryParse(textInputs[i], out parsedNums[i]));
            }

            Console.Clear();
            DrawDLine((int)parsedNums[0], (int)parsedNums[1], parsedNums[2], (int)parsedNums[3]);
        }


        static void DebugRectangle()
        {
            string[] textInputs = new string[4];
            int[] parsedNums = new int[textInputs.Length];
            string[] inputNames = { "top", "left", "height", "width" };

            for (int i = 0; i < textInputs.Length; i++)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please input the value for {0}", inputNames[i]);
                    textInputs[i] = Console.ReadLine();
                } while (!Int32.TryParse(textInputs[i], out parsedNums[i]));
            }

            Console.Clear();
            DrawRectangle(parsedNums[0], parsedNums[1], parsedNums[2], parsedNums[3]);
        }

        static void DebugCube()
        {
            string[] textInputs = new string[3];
            int[] parsedNums = new int[textInputs.Length];
            string[] inputNames = { "top", "left", "width" };

            for (int i = 0; i < textInputs.Length; i++)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please input the value for {0}", inputNames[i]);
                    textInputs[i] = Console.ReadLine();
                } while (!Int32.TryParse(textInputs[i], out parsedNums[i]));
            }

            Console.Clear();
            DrawCube(parsedNums[0], parsedNums[1], parsedNums[2]);
        }


        static void DebugGrid()
        {
            string[] textInputs = new string[5];
            int[] parsedNums = new int[textInputs.Length];
            string[] inputNames = { "top", "left", "cell size", "columns", "rows" };

            for (int i = 0; i < textInputs.Length; i++)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please input the value for {0}", inputNames[i]);
                    textInputs[i] = Console.ReadLine();
                } while (!Int32.TryParse(textInputs[i], out parsedNums[i]));
            }

            Console.Clear();
            DrawGrid(parsedNums[0], parsedNums[1], parsedNums[2], parsedNums[3], parsedNums[4]);
        }
        #endregion MenuFunctions

        static void DrawVLine(int top, int left, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(linechar);
            }
        }

        static void DrawHLine(int top, int left, int width)
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(left + i, top);
                Console.Write(linechar);
            }
        }

        static void DrawDLine(int top, int left, double angle, int length)
        {
            double stepX = Math.Cos(angle * (Math.PI / 180d));
            double stepY = Math.Sin(angle * (Math.PI / 180d));
            stepY = -stepY;

            double currentX = left;
            double currentY = top;
            while (Distance2D(left,top,currentX, currentY) < length)
            {
                Console.SetCursorPosition((int)currentX, (int)currentY);
                Console.Write(linechar);

                currentX += stepX;
                currentY += stepY;
            }
        }

        static void DrawRectangle(int top, int left, int height, int width)
        {
            DrawVLine(top, left, height);
            DrawVLine(top, left + width - 1, height);
            DrawHLine(top, left, width);
            DrawHLine(top + height - 1, left, width);
        }

        static void DrawCube(int top, int left, int width)
        {
            DrawRectangle(top, left + (width / 2), width, width);
            DrawRectangle(top + (width / 2), left, width, width);

            int w = (int)(width * 0.75d) - 1;
            float angle = 45 * 5;
            // Top
            //L
            DrawDLine(top, (int)(left + (width / 2f) + 1), angle, w);
            //R
            DrawDLine(top, (int)(left + (width / 2f) + width - 0.2f), angle, w);

            //Bottom
            //L
            DrawDLine((int)(top + width), (int)(left + (width / 2f)), angle, w);
            //R
            DrawDLine((int)(top + width), (int)(left + (width / 2f) + width - 1), angle, w);

        }

        static void DrawGrid(int top, int left, int cellSize, int cells, int columns)
        {
            for (int x = 0; x < cells; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    DrawRectangle(top + (y * (cellSize - 1)), left + (x * (cellSize - 1)), cellSize, cellSize);
                }
            }
        }


        static double Distance2D(double x, double y, double x2, double y2)
        {
            double distX = x2 - x;
            double distY = y2 - y;
            return Math.Sqrt((distX * distX) + (distY * distY));
        }


        static void InitConsole(int width, int height)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.SetWindowSize(width, height);
        }

        static void WriteMiddle(string text, int top)
        {
            int left = (Console.WindowWidth / 2) - (text.Length / 2);

            if (text.Length % 2 != 0)
            {
                left--;
            }

            Console.SetCursorPosition(left, top);
            Console.WriteLine(text);
        }
    }
}
