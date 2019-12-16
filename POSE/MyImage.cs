using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSE
{
    public class MyImage
    {
        public string imagePath, name;

        public MyImage(string imagePath, string name)
        {
            this.imagePath = imagePath;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
