using Snake.Interfaces;

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


        public Wall(float x, float y, float width, float height, Snake game)
        {
            this.Game = game;
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
            // TOP
            this.Game.MainDisplay.CurrentBuffer.DrawLine(1, 1, 1 + (int)this.width, 1, Snake.WALL_CHAR, System.ConsoleColor.White, System.ConsoleColor.White);
            // BOTTOM
            this.Game.MainDisplay.CurrentBuffer.DrawLine(1, 1 + (int)this.height, 1 + (int)this.width, 1 + (int)this.height, Snake.WALL_CHAR, System.ConsoleColor.White, System.ConsoleColor.White);
            // LEFT
            this.Game.MainDisplay.CurrentBuffer.DrawLine(1, 1, 1, 1 + (int)this.height, Snake.WALL_CHAR, System.ConsoleColor.White, System.ConsoleColor.White);
            // RIGHT
            this.Game.MainDisplay.CurrentBuffer.DrawLine(1 + (int)this.width, 1, 1 + (int)this.width, 1 + (int)this.height + 1, Snake.WALL_CHAR, System.ConsoleColor.White, System.ConsoleColor.White);

        }

        public void Tick()
        {
            // Don't Update -> It's a Wall.
            // But maybe check for collisions later (?)
        }
    }
}
