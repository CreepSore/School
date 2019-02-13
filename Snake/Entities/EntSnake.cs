using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Entities
{
    public class EntSnake : IEntity
    {
        public Snake Game { get; set; }
        public bool DoUpdate { get; set; } = false;
        public float x { get; set; }
        public float y { get; set; }

        public List<EntSnakeBody> bodyparts;

        public int InitialLength { get; set; }
        public int CurrentLength { get; set; }

        public EntSnake(int x, int y, int initialLength, Snake game)
        {
            this.Game = game;
            this.x = x;
            this.y = y;

            bodyparts = new List<EntSnakeBody>();
            this.InitialLength = initialLength;
        }

        public void Draw()
        {
            foreach (EntSnakeBody body in this.bodyparts)
            {
                body.Draw();
            }

            Console.SetCursorPosition((int)x, (int)y);
            Console.Write(Snake.SNAKE_HEAD_CHAR);
        }

        int dir = 0;
        public void Tick()
        {
            ConsoleKey pressedKey = (ConsoleKey)this.Game.MainInput.PressedKey;
            if (pressedKey == ConsoleKey.LeftArrow)
            {
                dir = -1;
            }
            if (pressedKey == ConsoleKey.RightArrow)
            {
                dir = 1;
            }
            if (pressedKey == ConsoleKey.UpArrow)
            {
                dir = 2;
            }
            if (pressedKey == ConsoleKey.DownArrow)
            {
                dir = -2;
            }

            float oldX = this.x;
            float oldY = this.y;
            if (dir == -1)
            {
                this.x--;
            }
            else if (dir == -2)
            {
                this.y++;
            }
            else if (dir == 1)
            {
                this.x++;
            }
            else if (dir == 2)
            {
                this.y--;
            }

            float newestPartX = oldX;
            float newestPartY = oldY;
            foreach (EntSnakeBody body in bodyparts)
            {
                newestPartX = body.x;
                newestPartY = body.y;
            }

            if (this.CurrentLength >= 1)
            {
                this.bodyparts[0].x = oldX;
                this.bodyparts[0].y = oldY;
                for (int i = 1; i < this.bodyparts.Count; i++)
                {
                    this.bodyparts[i].x = this.bodyparts[i - 1].x;
                    this.bodyparts[i].y = this.bodyparts[i - 1].y;
                }
            }

            if(this.CurrentLength < this.InitialLength)
            {

                bodyparts.Add(new EntSnakeBody(newestPartX, newestPartY, this, this.Game));
                this.CurrentLength++;
            }
        }

    }
}
