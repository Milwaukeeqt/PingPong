using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    class Ball
    {
        public Vector UpdateBallPos(PictureBox p, int velosity , Form form)
        {
            var X = p.Location.X + velosity;
            var Y = p.Location.Y + velosity;
            var V = velosity;

            //Top and Bottom
            if (Y < 0)
            {
                Y = -Y;
                V = -V;
            } else if (Y > (form.Height - 1))
            {
                Y -= 2*(Y - form.Height - 1);
                V = -V;
            }

            return new Vector(Y,V);
        }
    }
}
