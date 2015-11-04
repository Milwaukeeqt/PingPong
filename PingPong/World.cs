using System;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace PingPong
{
    public partial class World : Form
    {
        private readonly Timer _timer = new Timer();
        private const int PaddleSpeed = 10;
        private bool _playerUp, _playerDown;
        private bool _enemyUp, _enemyDown;
        private bool Running;
        private Ball ball;

        public World()
        {
            InitializeComponent();
            KeyDown += MyKeyDown;
            KeyUp += MyKeyUp;

            label1.Text = "Press Space to start game";
            ball = new Ball(new Vector( 2, 5), pictureBox2, this);

            pictureBox1.Location = new Point(this.Width-this.Width, this.Height/2);
            pictureBox3.Location = new Point(this.Width+this.Width, this.Height/2);
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
                ball.Move();
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
    }
}
