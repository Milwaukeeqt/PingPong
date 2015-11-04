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

        public bool HitTopWall()
        {
            return radius >= pictureBox.Location.Y;
        }

        public bool HitBottomWall(World w)
        {
            return w.Height - 1 == pictureBox.Location.Y + radius;
        }

        public bool HitLeftWall()
        {
            return radius >= pictureBox.Location.X;
        }

        public bool HitRightWall(World w)
        {
            return w.Width - 1 == pictureBox.Location.X + radius;
        }

        public void HandleCollision()
        {
            if (HitTopWall())
            {
                vector = vector.verticalFlip();
            }
            if (HitBottomWall(world))
            {
                vector = vector.verticalFlip();
            }
            if (HitLeftWall())
            {
                vector = vector.horizontalFlip();
            }
            if (HitRightWall(world))
            {
                vector = vector.horizontalFlip();
            }
        }
    }
}
