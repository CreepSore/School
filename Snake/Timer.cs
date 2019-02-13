using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Timer
    {

        long latestTick;

        public int TPS { get; }
        public float Speed { get; set; } = 1.0f;

        public Timer(int TPS)
        {
            this.TPS = TPS;
        }

        public bool RunTick()
        {
            if(Environment.TickCount - latestTick > (1000 / (TPS * Speed)))
            {
                latestTick = Environment.TickCount;
                return true;
            }

            return false;
        }

    }
}
