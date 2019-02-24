using Snake.Entities;
using Snake.Interfaces;
using Snake.Rendering;
using System;
using System.Collections.Generic;

namespace Snake
{
    public class Snake
    {
        public static Random GlobalRandom = new Random();

        public const char WALL_CHAR = '#';

        public const char SNAKE_HEAD_CHAR = (char)1;
        public const char SNAKE_BODY_CHAR = '+';

        public const char FOOD_CHAR = (char)4;

        public const int FRUIT_SCORE = 100;

        public Timer MainTimer { get; }
        public Input MainInput { get; }
        public Display MainDisplay { get; }
        public IEntity MainSnake { get; set; }

        public int Score { get; set; }

        public bool IsRunning { get; set; } = false;

        List<IEntity> entities = new List<IEntity>();

        List<IEntity> markedForSpawn = new List<IEntity>();
        List<IEntity> markedForDespawn = new List<IEntity>();

        public Snake()
        {
            this.MainTimer = new Timer(8);
            this.MainInput = new Input();
            this.MainDisplay = new Display(-1, -1);

            this.SetupMap();
            entities.Add(new EntSnake(Program.WIN_WIDTH / 2, Program.WIN_HEIGHT / 2, 4, this));

            this.SpawnFruit();
        }

        public void SetupMap()
        {
            entities.Add(new Wall(1, 1, Program.WIN_WIDTH - 3, Program.WIN_HEIGHT - 3, this));
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

                foreach (IEntity ent in entities)
                {
                    ent.Tick();
                    ent.Draw();
                }

                this.DespawnQueuedEntities();
                this.SpawnQueuedEntities();

                this.MainDisplay.CurrentBuffer.ClearArea(0, 0, 10, 0);
                this.MainDisplay.CurrentBuffer.SetText(0, 0, string.Format("Score: {0}", this.Score));
                this.MainDisplay.Draw();
                this.MainDisplay.CurrentBuffer.ClearArea(2, 2, Program.WIN_WIDTH - 2, Program.WIN_HEIGHT - 2);

                // Reset Input
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

        public List<T> GetEntitiesByType<T>()
        {
            List<T> ents = new List<T>();
            foreach (IEntity o in this.entities)
            {
                if (o is T)
                {
                    ents.Add((T)o);
                }
            }
            return ents;
        }

        public List<Wall> GetWalls()
        {
            return GetEntitiesByType<Wall>();
        }

        public List<Fruit> GetFruits()
        {
            return GetEntitiesByType<Fruit>();
        }
    }
}
