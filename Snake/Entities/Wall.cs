﻿using Snake.Interfaces;
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


        public Wall()
        {
            
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
