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
        private PictureBox ball;
        private readonly World world;

        public Ball(Vector vector, PictureBox ball, World world)
        {
            this.vector = vector;
            this.radius = ball.Width/2;
            this.ball = ball;
            this.world = world;
        }

        public void Move()
        {
            ball.Location = new Point(ball.Location.X + vector.x, ball.Location.Y + vector.y);
            HandleCollision();
        }

        public void HandleCollision()
        {
            if (Collision.Up(ball))
            {
                vector = vector.VerticalFlip();
            }
            if (Collision.Down(ball,world.Height))
            {
                vector = vector.VerticalFlip();
            }
            if (Collision.Left(ball))
            {
                vector = vector.HorizontalFlip();
            }
            if (Collision.Right(ball,world.Width))
            {
                vector = vector.HorizontalFlip();
            }
        }

        public void HandlePaddleCollision(PictureBox paddle)
        {
            if (Collision.HitPaddle(paddle, ball))
            {
                vector = vector.VerticalFlip();
            }
        }
    }
}
