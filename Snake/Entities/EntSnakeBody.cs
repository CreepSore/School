using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Entities
{
    public class EntSnakeBody : IEntity
    {

        public Snake Game { get; set; }
        public bool DoUpdate { get; set; } = false;
        public float x { get; set; }
        public float y { get; set; }

        public float lastX { get; set; }
        public float lastY { get; set; }

        public EntSnake Parent { get; set; }

        public EntSnakeBody(float x, float y, EntSnake parent, Snake game)
        {
            this.Game = game;
            this.x = x;
            this.y = y;
            this.Parent = parent;
        }

        public void Draw()
        {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write(Snake.SNAKE_BODY_CHAR);
        }

        public void Tick()
        {
            this.lastX = this.x;
            this.lastY = this.y;
            // Gets Handled in Parent Snake
        }
    }
}