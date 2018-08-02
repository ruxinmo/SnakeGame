using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Assignment_SnakeGame
{
    public partial class Form1 : Form
    {
        private Palette p;
        private int speedindex = 0;
        private int width = 15 ;
        private int height=15;
        private int size = 15;
        private bool hasgone = false;
        
        

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && p.Direction != Direction.Down)
            {
                p.Direction = Direction.Up;
            }
            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && p.Direction != Direction.Up)
            {
                p.Direction = Direction.Down;
            }
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && p.Direction != Direction.Right)
            {
                p.Direction = Direction.Left;
            }
            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && p.Direction != Direction.Left)
            {
                p.Direction = Direction.Right;
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            hasgone = true;


            this.pictureBox1.Width = width * size;
            this.pictureBox1.Height = height * size;
            this.Width = pictureBox1.Width + 60;
            this.Height = pictureBox1.Height + 120;

            p = new Palette(width, height, size, this.pictureBox1.BackColor, Graphics.FromHwnd(this.pictureBox1.Handle), speedindex, labelScore);

            
            p.start();

            
        }
        

        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
