using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    class Vector
    {
        public Vector(int coordinat, int velosity)
        {
            Coordinat = coordinat;
            Velosity = velosity;
        }

        public int Coordinat  { get; set; }

        public int Velosity { get; set; }
    }
}
