using Snake.Entities;
using Snake.Interfaces;
using System;
using System.Collections.Generic;

namespace Snake
{
    public class Snake
    {
        public static Random GlobalRandom = new Random();

        public const char WALL_CHAR = '#';

        public const char SNAKE_HEAD_CHAR = 'O';
        public const char SNAKE_BODY_CHAR = '+';

        public const char FOOD_CHAR = '·';

        public const int FRUIT_SCORE = 100;

        public Timer MainTimer { get; }
        public Input MainInput { get; }
        public IEntity MainSnake { get; set; }

        public int Score { get; set; }

        public bool IsRunning { get; set; } = false;

        List<IEntity> entities = new List<IEntity>();

        List<IEntity> markedForSpawn = new List<IEntity>();
        List<IEntity> markedForDespawn = new List<IEntity>();

        public Snake()
        {
            this.MainTimer = new Timer(16);
            this.MainInput = new Input();

            entities.Add(new Wall(1, 1, Program.WIN_WIDTH - 3, Program.WIN_HEIGHT - 3));
            entities.Add(new EntSnake(Program.WIN_WIDTH / 2, Program.WIN_HEIGHT / 2, 4, this));

            this.SpawnFruit();
        }

        public void Start()
        {
            this.IsRunning = true;
            Loop();
            GameOver();
        }

        public void Loop()
        {
            while (this.IsRunning)
            {
                // Saving CPU power
                System.Threading.Thread.Sleep(1);

                // Has to be Ticked every Loop, so no Keypresses will be lost
                this.MainInput.Tick();
                if (!MainTimer.RunTick())
                {
                    continue;
                }

                Program.InitConsole();

                Console.Clear();

                foreach (IEntity ent in entities)
                {
                    ent.Tick();
                    ent.Draw();
                }

                Console.SetCursorPosition(0, 0);
                Console.Write("Score: {0}", this.Score);

                this.DespawnQueuedEntities();
                this.SpawnQueuedEntities();

                this.MainInput.KeyIsPressed = false;
                this.MainInput.PressedKey = (int)ConsoleKey.NoName;
            }
        }

        public void GameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.Write("Game Over!");
            Console.SetCursorPosition(10, 11);
            Console.Write("Score: {0}", this.Score);

            Console.ReadLine();
        }

        public void SpawnFruit(int startX, int startY, int endX, int endY)
        {
            this.markedForSpawn.Add(new Fruit(GlobalRandom.Next(startX, endX), GlobalRandom.Next(startY, endY), this));
        }

        private void SpawnQueuedEntities()
        {
            foreach (IEntity ent in markedForSpawn)
            {
                this.entities.Add(ent);
            }
            this.markedForSpawn.Clear();
        }

        public void SpawnFruit()
        {
            this.SpawnFruit(2, 2, 2 + Program.WIN_WIDTH - 4, 2 + Program.WIN_HEIGHT - 4);
        }

        public void DespawnEntity(IEntity ent)
        {
            this.markedForDespawn.Add(ent);
        }

        private void DespawnQueuedEntities()
        {
            foreach (IEntity ent in markedForDespawn)
            {
                this.entities.Remove(ent);
            }
            this.markedForDespawn.Clear();
        }

        public List<Wall> GetWalls()
        {
            List<Wall> walls = new List<Wall>();
            foreach (IEntity w in this.entities)
            {
                if (w is Wall)
                {
                    walls.Add((Wall)w);
                }
            }
            return walls;
        }

        public List<Fruit> GetFruits()
        {
            List<Fruit> fruits = new List<Fruit>();
            foreach (IEntity f in this.entities)
            {
                if (f is Fruit)
                {
                    fruits.Add((Fruit)f);
                }
            }
            return fruits;
        }
    }
}
