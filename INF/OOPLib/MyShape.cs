using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLib
{
    public abstract class MyShape
    {
        #region Members
        private int x1, y1;
        private int x2, y2;
        #endregion

        #region Properties
        public int X1
        {
            get => x1;
            set
            {
                if (value < 0)
                    x1 = 0;
                else if (value > 1000)
                    x1 = 1000;
                else
                    x1 = value;
            }
        }
        public int X2 { get => x2; set => x2 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int Y2 { get => y2; set => y2 = value; }
        #endregion

        #region Constructor
        public MyShape() { }

        public MyShape(int x1, int y1)
        {
            this.X1 = x1;
            this.y1 = y1;
        }

        public MyShape(int x1, int y1, int x2, int y2) : this(x1, y1)
        {
            this.x2 = x2;
            this.y2 = y2;
        }
        #endregion

        #region Methods
        public abstract void Draw();

        public void Move(int dx, int dy)
        {
            this.X1 += dx;
            this.Y1 += dy;

            this.X2 += dx;
            this.Y2 += dy;
        }
        #endregion
    }
}
