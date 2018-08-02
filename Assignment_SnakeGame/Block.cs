using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_SnakeGame
{
    class Block
    {
        private Color Sncolor;
        private int Snsize;
        private Point Snpoint;

        public Block(Color color, int size, Point p)
        {
            this.Sncolor = color;
            this.Snsize = size;
            this.Snpoint = p;
        }

        public Point Point
        {
            get { return this.Snpoint; }
        }

        
        public virtual void Paint(Graphics g)
        {
            SolidBrush sb = new SolidBrush(Sncolor);
            lock (g)
            {
                try
                {
                    g.FillRectangle(sb, this.Point.X * this.Snsize, this.Point.Y * this.Snsize, this.Snsize - 1, this.Snsize - 1);
                }
                catch
                {
                }
            }
        }
    }
}
