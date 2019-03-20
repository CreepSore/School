using OOPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTester
{
    class Program
    {
        static void Main(string[] args)
        {

            MyLine line1 = new MyLine(10, 10, 10, 10);
            MyRectangle rect1 = new MyRectangle(10, 10, 20, 20);


            line1.Draw();
            line1.Move(10, 10);
            line1.Draw();

            rect1.Draw();
            rect1.Move(10, 5);
            rect1.Draw();

            Console.ReadKey(true);

        }
    }
}
