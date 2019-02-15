using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class RenderUtils
    {
        public static void DrawHorizontalLine(int x, int y, int length, char character)
        {
            for(int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write(character);
            }
        }

        public static void DrawVerticalLine(int x, int y, int length, char character)
        {
            for(int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(character);
            }
        }

        public static void DrawRectangle(int offsetX, int offsetY, int width, int height, char character)
        {
            DrawHorizontalLine(offsetX, offsetY, width, character);
            DrawHorizontalLine(offsetX, offsetY + height, width + 1, character);

            DrawVerticalLine(offsetX, offsetY, height, character);
            DrawVerticalLine(offsetX + width, offsetY, height, character);
        }

    }
}
