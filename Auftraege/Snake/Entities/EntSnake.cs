using Snake.Interfaces;
using System;
using System.Collections.Generic;

namespace Snake.Entities
{
    public class EntSnake : IEntity
    {
        public Snake Game { get; set; }
        public bool DoUpdate { get; set; } = true;
        public float x { get; set; }
        public float y { get; set; }

        public float lastX { get; set; }
        public float lastY { get; set; }

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

            this.Game.MainDisplay.CurrentBuffer.SetChar((int)x, (int)y, Snake.SNAKE_HEAD_CHAR, ConsoleColor.Green);
        }

        int dir = 0;
        public void Tick()
        {
            if (!this.DoUpdate)
            {
                return;
            }

            ConsoleKey pressedKey = (ConsoleKey)this.Game.MainInput.PressedKey;
            if (pressedKey == ConsoleKey.LeftArrow && dir != 1)
            {
                dir = -1;
            }
            if (pressedKey == ConsoleKey.RightArrow && dir != -1)
            {
                dir = 1;
            }
            if (pressedKey == ConsoleKey.UpArrow && dir != -2)
            {
                dir = 2;
            }
            if (pressedKey == ConsoleKey.DownArrow && dir != 2)
            {
                dir = -2;
            }

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

            if (dir >= -2 && dir <= 2)
            {
                if (this.CurrentLength >= 1)
                {
                    this.bodyparts[0].x = lastX;
                    this.bodyparts[0].y = lastY;
                    for (int i = this.bodyparts.Count - 1; i > 0; i--)
                    {
                        this.bodyparts[i].x = this.bodyparts[i - 1].x;
                        this.bodyparts[i].y = this.bodyparts[i - 1].y;
                    }
                }

                foreach (Wall w in this.Game.GetWalls())
                {
                    if (w.CheckCollision(this))
                    {
                        this.x = lastX;
                        this.y = lastY;
                        this.DoUpdate = false;
                        this.Game.IsRunning = false;
                    }
                }

                bool FruitCollision = false;
                foreach (Fruit f in this.Game.GetFruits())
                {
                    if (f.CheckCollision(this))
                    {
                        FruitCollision = true;
                        this.Game.DespawnEntity(f);
                        this.Game.SpawnFruit();
                        
                        // Spawn another Fruit every 500 Points
                        if(this.Game.Score % 1000 == 400)
                        {
                            this.Game.SpawnFruit();
                        }

                        this.Game.Score += Snake.FRUIT_SCORE;

                        this.Game.MainTimer.Speed += 0.1f;
                        break;
                    }
                }

                if (this.CheckOwnCollision())
                {
                    this.DoUpdate = false;
                    this.Game.IsRunning = false;
                }

                if ((dir >= -2 && dir <= 2) && (FruitCollision || this.CurrentLength < this.InitialLength))
                {
                    Grow();
                }

                lastX = this.x;
                lastY = this.y;
            }
        }

        public bool CheckOwnCollision()
        {
            foreach (EntSnakeBody part in bodyparts)
            {
                if (bodyparts.IndexOf(part) < 4)
                {
                    continue;
                }

                if (part.x == this.x && part.y == this.y)
                {
                    return true;
                }
            }
            return false;
        }

        public void Grow()
        {
            float newestPartX = this.lastX;
            float newestPartY = this.lastY;
            foreach (EntSnakeBody body in bodyparts)
            {
                newestPartX = body.x;
                newestPartY = body.y;
            }

            bodyparts.Add(new EntSnakeBody(newestPartX, newestPartY, this, this.Game));
            this.CurrentLength++;
        }

        public void Shrink()
        {
            bodyparts.RemoveAt(bodyparts.Count - 1);
            this.CurrentLength--;
        }
    }
}
