using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        private int speed_vertical = 4;
        private int speed_hor = 4;
        private int score;
        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Bounds = Screen.PrimaryScreen.Bounds;

            gamePanel.Top = background.Bottom - (background.Bottom / 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            gameBall.Left += speed_hor;
            gameBall.Top += speed_vertical;

            
            if (gameBall.Left <= background.Left)
                speed_hor *= -1;

            if (gameBall.Right >= background.Right)
                speed_hor *= -1;
            
            if (gameBall.Top <= background.Top)
                speed_vertical *= -1;
            
            if (gameBall.Bottom >= background.Bottom)
                timer.Enabled = false;

            if(gameBall.Bottom >= gamePanel.Top && gameBall.Bottom <= gamePanel.Bottom 
                && gameBall.Left >= gamePanel.Left && gameBall.Right <= gamePanel.Right)
            {
                speed_hor += 3;
                speed_vertical += 3;
                speed_vertical *= -1;
                score += 1;
            }
        }
    }
}
