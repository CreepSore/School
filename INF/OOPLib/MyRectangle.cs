using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLib
{
    public class MyRectangle : Object
    {

        #region Members
        private int x1, y1;
        private int x2, y2;
        #endregion

        #region Properties
        public int X1 { get => x1; set => x1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int Y2 { get => y2; set => y2 = value; }
        #endregion

        #region Constructor
        public MyRectangle() { }

        public MyRectangle(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        #endregion

        #region Methods
        public void Draw()
        {
            Console.WriteLine($"Retangle(XY)={X1},{Y1}; {X2},{Y2}");
        }

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
