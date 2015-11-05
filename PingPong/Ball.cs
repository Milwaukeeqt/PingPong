using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    class Ball
    {
        private Vector vector;
        private readonly int radius;
        private PictureBox pictureBox;
        private readonly World world;

        public Ball(Vector vector, PictureBox pictureBox, World world)
        {
            this.vector = vector;
            this.radius = pictureBox.Width/2;
            this.pictureBox = pictureBox;
            this.world = world;
        }

        public void Move()
        {
            pictureBox.Location = new Point(pictureBox.Location.X + vector.x, pictureBox.Location.Y + vector.y);
            HandleCollision();
        }

        public void HandleCollision()
        {
            if (Collision.Up(pictureBox))
            {
                vector = vector.VerticalFlip();
            }
            if (Collision.Down(pictureBox,world.Height))
            {
                vector = vector.VerticalFlip();
            }
            if (Collision.Left(pictureBox))
            {
                vector = vector.HorizontalFlip();
            }
            if (Collision.Right(pictureBox,world.Width))
            {
                vector = vector.HorizontalFlip();
            }
        }
    }
}
