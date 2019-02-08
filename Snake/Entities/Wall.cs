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
        public int x { get; set; }
        public int y { get; set; }



        public Wall()
        {
            
        }

        public void Draw()
        {
            RenderUtils.DrawRectangle(x, y, Program.WIN_WIDTH, Program.WIN_HEIGHT, Snake.WALL_CHAR);
        }

        public void Tick()
        {
            // Don't Update -> It's a Wall.
            // But maybe check for collisions later (?)
        }
    }
}
