using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    class Collision
    {
        public static bool Up(PictureBox p)
        {
            return p.Location.Y < 0;
        }

        public static bool Down(PictureBox p, int height)
        {
            return p.Location.Y + p.Height > height;
        }

        public static bool Left(PictureBox p)
        {
            return p.Location.X < 0;
        }

        public static bool Right(PictureBox p, int width)
        {
            return p.Location.X + p.Width > width;
        }
    }
}
