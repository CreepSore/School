using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Entities
{
    public class Wall : IEntity
    {
        public Snake Game { get; set; }
        public bool DoUpdate { get; set; } = false;
        public float x { get; set; } = 1;
        public float y { get; set; } = 1;

        public float height { get; set; }
        public float width { get; set; }


        public Wall(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public bool CheckCollision(IEntity ent)
        {
            bool leftWall = (ent.y >= this.y && ent.y <= this.y + height && ent.x == x);
            bool rightWall = (ent.y >= this.y && ent.y <= this.y + height && ent.x == x + width);
            bool topWall = (ent.x >= this.x && ent.x <= this.x + width && ent.y == y);
            bool bottomWall = (ent.x >= this.x && ent.x <= this.x + width && ent.y == y + height);

            if (leftWall || rightWall || topWall || bottomWall)
            {
                return true;
            }

            return false;
        }

        public void Draw()
        {
            RenderUtils.DrawRectangle((int)x, (int)y, Program.WIN_WIDTH - 3, Program.WIN_HEIGHT - 3, Snake.WALL_CHAR);
        }

        public void Tick()
        {
            // Don't Update -> It's a Wall.
            // But maybe check for collisions later (?)
        }
    }
}
