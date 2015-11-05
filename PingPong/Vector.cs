using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    class Vector
    {
        public int x { get; set; }

        public int y { get; set; }

        public Vector(int y, int x)
        {
            this.y = y;
            this.x = x;
        }

        public Vector VerticalFlip()
        {
            return new Vector(x, -y);
        }

        public Vector HorizontalFlip()
        {
            return new Vector(-x, y);
        }

        public double Lenght()
        {
            return Math.Sqrt(x*x + y*y);
        }

        public Vector Scale(int scalar)
        {
            return new Vector(x*scalar, y*scalar);
        }
    }
}
