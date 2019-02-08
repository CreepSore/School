using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Interfaces
{
    public interface IEntity : IDrawable, ITickable
    {
        Snake Game { get; set; }
        bool DoUpdate { get; set; }

        int x { get;set; }
        int y { get; set; }
    }
}
