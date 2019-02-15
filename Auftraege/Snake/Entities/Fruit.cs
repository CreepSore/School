using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Entities
{
    public class Fruit : IEntity
    {
        public Snake Game { get; set; }
        public bool DoUpdate { get; set; } = false;
        public float x { get; set; }
        public float y { get; set; }

        public Fruit(int x, int y, Snake game)
        {
            this.x = x;
            this.y = y;
            this.Game = game;
        }

        public bool CheckCollision(IEntity ent)
        {
            if(this.x == ent.x && this.y == ent.y)
            {
                return true;
            }

            return false;
        }

        public void Draw()
        {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write('+');
        }

        public void Tick()
        {
            // Collision-Checking gets done in EntSnake
        }
    }
}
