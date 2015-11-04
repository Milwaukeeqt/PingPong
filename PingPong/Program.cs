using System;
using System.Windows.Forms;

namespace PingPong
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var myForm = new Form1();
            myForm.Show();
            myForm.GameLoop();
        }
    }
}
