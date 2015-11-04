using System;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        private readonly Timer _timer = new Timer();
        private const int PaddleSpeed = 10;
        private int BallVelosity = 5;
        private bool _playerUp, _playerDown;
        private bool _enemyUp, _enemyDown;
        private bool Running;

        public Form1()
        {
            this.Height = 480;
            this.Width = 620;
            InitializeComponent();
            KeyDown += MyKeyDown;
            KeyUp += MyKeyUp;

            label1.Text = "Press Space to start game";
        }

        public void GameLoop()
        {
            while (this.Created)
            {
                _timer.Reset();
                RenderScene();
                Application.DoEvents();
                while (_timer.GetTicks() < 10) { };
            }
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _playerUp = true;
                    _playerDown = false;
                    break;
                case Keys.W:
                    _enemyUp = true;
                    _enemyDown = false;
                    break;
                case Keys.Down:
                    _playerUp = false;
                    _playerDown = true;
                    break;
                case Keys.S:
                    _enemyUp = false;
                    _enemyDown = true;
                    break;
                case Keys.Space:
                    Running = true;
                    label1.Hide();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _playerUp = false;
                    break;
                case Keys.W:
                    _enemyUp = false;
                    break;
                case Keys.Down:
                    _playerDown = false;
                    break;
                case Keys.S:
                    _enemyDown = false;
                    break;
            }
        }

        public void RenderScene()
        {
            if (Running)
            {
                MovePaddles();
                MoveBall();
            }
        }

        public void MovePaddles()
        {
            var x = pictureBox1.Location.X;
            var y = pictureBox1.Location.Y;
            var x2 = pictureBox3.Location.X;
            var y2 = pictureBox3.Location.Y;

            if (_playerUp && !Collision.Up(pictureBox1))
            {
                pictureBox1.Location = new Point(x, y -= PaddleSpeed);
            }
            if (_playerDown && !Collision.Down(pictureBox1, Height))
            {
                pictureBox1.Location = new Point(x, y += PaddleSpeed);
            }
            if (_enemyUp && !Collision.Up(pictureBox3))
            {
                pictureBox3.Location = new Point(x2, y2 -= PaddleSpeed);
            }
            if (_enemyDown && !Collision.Down(pictureBox3, Height))
            {
                pictureBox3.Location = new Point(x2, y2 += PaddleSpeed);
            }
        }

        public void MoveBall()
        {
            var updatedBall = new Ball().UpdateBallPos(pictureBox2, BallVelosity, this);
            pictureBox2.Top = updatedBall.Coordinat;
            BallVelosity = updatedBall.Velosity;

            if(updatedBall.Coordinat >= pictureBox1.Bounds.Y && updatedBall.Coordinat <= pictureBox1.Bounds.Y - pictureBox1.Height)
            {
                var bounceAngle = ((pictureBox1.Top/2))/(pictureBox1.Top/2)*(Math.PI/2 - (Math.PI/12));
                BallVelosity = (int) Math.Sqrt(BallVelosity*BallVelosity);

                pictureBox2.Left = (int) (BallVelosity * Math.Cos(bounceAngle));
            }
        }
    }
}
