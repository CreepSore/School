using Snake.Entities;
using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public static Random GlobalRandom = new Random();

        public const char WALL_CHAR = '#';

        public const char SNAKE_HEAD_CHAR = 'O';
        public const char SNAKE_BODY_CHAR = '#';

        public Timer MainTimer { get; }
        public Input MainInput { get; }
        public IEntity MainSnake { get; set; }

        public bool IsRunning { get; set; } = false;

        List<IEntity> entities = new List<IEntity>();

        public Snake()
        {
            this.MainTimer = new Timer(10);
            this.MainInput = new Input();

            entities.Add(new Wall());
            entities.Add(new Fruit(5,8));
        }

        public void Start()
        {
            this.IsRunning = true;
            Loop();
        }

        public void Loop()
        {
            while(this.IsRunning)
            {
                // Saving CPU power
                System.Threading.Thread.Sleep(1);

                if(!MainTimer.RunTick())
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
            }
        }
    }
}
