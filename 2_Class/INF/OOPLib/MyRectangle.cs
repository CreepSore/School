using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLib
{
    public class MyRectangle : MyShape
    {

        public MyRectangle(int x1, int y1) : base(x1, y1) { }
        public MyRectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw()
        {
            Console.WriteLine($"Rectangle(XY)={X1},{Y1}; {X2},{Y2}");
        }

    }
}
