using Snake.Interfaces;
using System;

namespace Snake.Rendering
{
    public class Display : IDrawable
    {
        public DisplayBuffer CurrentBuffer { get; set; }


        public Display(int width, int height)
        {
            this.CurrentBuffer = new DisplayBuffer(width, height);
        }


        public void Draw()
        {
            this.Draw(CurrentBuffer);
        }

        public void Draw(DisplayBuffer toDraw)
        {
            toDraw.DrawOnConsole();
        }
    }

    public class DisplayBuffer
    {
        // We use ints to store more states than just chars (transparent parts for example)
        int[,] buffer;
        int[,] lastBuffer;
        ConsoleColor[,] backgroundColors;
        ConsoleColor[,] foregroundColors;


        public DisplayBuffer(int width = -1, int height = -1)
        {
            if (width < 0)
            {
                width = Console.BufferWidth;
            }

            if (height < 0)
            {
                height = Console.BufferHeight;
            }

            buffer = new int[width, height];
            backgroundColors = new ConsoleColor[width, height];
            foregroundColors = new ConsoleColor[width, height];

            for (int x = 0; x < this.GetWidth(); x++)
            {
                for (int y = 0; y < this.GetHeight(); y++)
                {
                    foregroundColors[x, y] = ConsoleColor.White;
                }
            }
        }

        #region RenderFunctions

        public void DrawOnConsole()
        {
            for (int y = 0; y < this.GetHeight(); y++)
            {
                for (int x = 0; x < this.GetWidth(); x++)
                {

                    int currentState = this.buffer[x, y];
                    if (currentState == 0)
                    {
                        continue;
                    }

                    if (currentState == -2 || currentState == -3|| currentState >= 0 && currentState <= 255)
                    {
                        if (lastBuffer != null && lastBuffer[x, y] == this.buffer[x, y])
                        {
                            continue;
                        }

                        char currentChar;
                        if (currentState == -2)
                        {
                            if (lastBuffer == null)
                            {
                                continue;
                            }

                            currentChar = (char)lastBuffer[x, y];
                        }
                        else if (currentState == -3)
                        {
                            currentChar = ' ';
                        }
                        else
                        {
                            currentChar = (char)currentState;
                        }

                        Console.ForegroundColor = foregroundColors[x, y];
                        Console.BackgroundColor = backgroundColors[x, y];
                        Console.SetCursorPosition(x, y);
                        Console.Write(currentChar);
                        if (currentState == -3)
                        {
                            this.buffer[x, y] = 0;
                        }
                    }
                }
            }

            lastBuffer = new int[this.GetWidth(), this.GetHeight()];
            for (int y = 0; y < this.GetHeight(); y++)
            {
                for (int x = 0; x < this.GetWidth(); x++)
                {

                    lastBuffer[x, y] = buffer[x, y];
                }
            }
        }

        public void SetChar(int x, int y, char c,
            ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            if (x < 0 || x > this.GetWidth())
            {
                return;
            }
            if (y < 0 || y > this.GetHeight())
            {
                return;
            }

            this.buffer[x, y] = c;
        }

        public void SetText(int x, int y, string text, bool vertical = false,
            ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (vertical)
                {
                    SetChar(x, y + i, text[i], foreground, background);
                }
                else
                {
                    SetChar(x + i, y, text[i], foreground, background);
                }
            }
        }

        public void DrawLine(int x, int y, int x2, int y2, char c,
            ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            double stepX, stepY;
            double dist, distX, distY;

            distX = x2 - x;
            distY = y2 - y;
            dist = Math.Sqrt((distX * distX) + (distY * distY));

            stepX = distX / dist;
            stepY = distY / dist;

            for (double currentX = x, currentY = y; (int)currentX != x2 || (int)currentY != y2; currentX += stepX, currentY += stepY)
            {
                SetChar((int)currentX, (int)currentY, c, foreground, background);
            }
        }

        #endregion


        #region BufferFunctions
        public int GetWidth()
        {
            return buffer.GetLength(0);
        }

        public int GetHeight()
        {
            return buffer.GetLength(1);
        }

        public void ClearBuffer()
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
            {
                for (int y = 0; y < buffer.GetLength(1); y++)
                {
                    buffer[x, y] = ' ';
                }
            }
        }

        public void ClearArea(int x, int y, int x2, int y2)
        {
            for (int cx = x; cx < x2; cx++)
            {
                for (int cy = y; cy < y2; cy++)
                {
                    if (buffer[cx, cy] > 0)
                    {
                        buffer[cx, cy] = (int)EnumSpecialStates.CLEAR;
                    }
                }
            }
        }

        public void ReplaceChars(char oldChar, char newChar)
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
            {
                for (int y = 0; y < buffer.GetLength(1); y++)
                {
                    if (buffer[x, y] == oldChar)
                    {
                        buffer[x, y] = newChar;
                    }
                }
            }
        }

        public bool IsSame(DisplayBuffer toCompare)
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
            {
                for (int y = 0; y < buffer.GetLength(1); y++)
                {
                    if (this.buffer[x, y] != toCompare.buffer[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion BufferFunctions

        public enum EnumSpecialStates
        {
            TRANSPARENT = -1,
            FORCE_REDRAW = -2,
            CLEAR = -3
        }
    }
}
