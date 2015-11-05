using System;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace PingPong
{
    public partial class World : Form
    {
        private readonly Timer _timer = new Timer();
        private bool _playerUp, _playerDown;
        private bool _enemyUp, _enemyDown;
        private bool Running;
        private Ball ball;
        private Paddle player1;
        private Paddle player2;

        public World()
        {
            InitializeComponent();
            KeyDown += MyKeyDown;
            KeyUp += MyKeyUp;

            label1.Text = "Press Space to start game";
            ball = new Ball(new Vector( -5, 5), pictureBox2, this);
            player1 = new Paddle(pictureBox3,this);
            player2 = new Paddle(pictureBox1,this);
        }

        public void GameLoop()
        {
            while (this.Created)
            {
                _timer.Reset();
                RenderScene();
                Application.DoEvents();
                while (_timer.GetTicks() < 20);
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
                    if (Running == false)
                    {
                        this.Text = "World";
                        Running = true;
                    }
                    else
                    {
                        this.Text = "World - Paused";
                        Running = false;
                    }
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

        private void World_Load(object sender, EventArgs e)
        {

        }

        public void RenderScene()
        {
            if (Running)
            {
                player1.MovePaddles(_playerUp,_playerDown);
                player2.MovePaddles(_enemyUp,_enemyDown);
                ball.Move();
                ball.HandlePaddleCollision(pictureBox1);
                ball.HandlePaddleCollision(pictureBox3);
            }
        }

        
    }
}
