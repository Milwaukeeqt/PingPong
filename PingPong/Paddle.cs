using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    class Paddle
    {
        private PictureBox pictureBox;
        private Form form;
        private const int PaddleSpeed = 10;
        private int x;
        private int y;

        public Paddle(PictureBox pictureBox, Form form)
        {
            x = pictureBox.Location.X;
            y = pictureBox.Location.Y;
            this.form = form;
            this.pictureBox = pictureBox;
        }

        public void MovePaddles(bool Up, bool Down)
        {
            if (Up && !Collision.Up(pictureBox))
            {
                pictureBox.Location = new Point(x, y -= PaddleSpeed);
            }
            if (Down && !Collision.Down(pictureBox, form.Height))
            {
                pictureBox.Location = new Point(x, y += PaddleSpeed);
            }
        }
    }
}
