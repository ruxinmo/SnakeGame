using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.Collections;

namespace Assignment_SnakeGame
{
    class Palette
    {
        private int _width;
        private int _height;
        private Color _bgColor;
        private Graphics _gpPalette;
        private ArrayList _blocks;
        private Direction _direction;
        private Timer timerBlock;
        private Block _food;
        private int _size;
        private System.Windows.Forms.Label scoreLable;
        private int _speed=250;
        private int _speed2 = 150;

        public Palette(int width, int height, int size, Color bgColor, Graphics g, int lvl, System.Windows.Forms.Label scoreLable)
        {
            this._width = width;
            this._height = height;
            this._bgColor = bgColor;
            this._gpPalette = g;
            this._size = size;
            
            this._blocks = new ArrayList();
            this._blocks.Insert(0, (new Block(Color.Green, this._size, new Point(1, 1))));
            this._direction = Direction.Right;
            this.scoreLable = scoreLable;
        }

        public Direction Direction
        {
            get
            {
                return this._direction;
            }
            set
            {
                this._direction = value;
            }
        }
        
            
        
        public void start()
        {
                this._food = getFood();
                timerBlock = new System.Timers.Timer(_speed);              
                timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnBlockTimeEvent);
                timerBlock.AutoReset = true;
                timerBlock.Start();   
            
               
         }    
               
        
        private void OnBlockTimeEvent(object sourse, ElapsedEventArgs e)
        {
            this.move();
            if (this.CheckDead())
            {
                this.timerBlock.Stop();
                this.timerBlock.Dispose();
                System.Windows.Forms.MessageBox.Show("Thanks to playing this game,your Score is "+ this._blocks.Count, "Game Over");
                System.IO.File.AppendAllText("Score.txt", this._blocks.Count + Environment.NewLine);   
                if (_blocks.Count>=5)
                {
                    timerBlock.Stop();
                }
            }
        }
        public void Stop()
        {
            
            this.timerBlock.Stop();
            this.timerBlock.Dispose();
            this._blocks.RemoveRange(0, this._blocks.Count);

        }

        
        private bool CheckDead()
        {
            Block head = (Block)(this._blocks[0]);
            
            if (head.Point.X < 0 || head.Point.Y < 0 || head.Point.X + 1 > this._width || head.Point.Y + 1 > this._height)
            {
                return true;
            }
            for (int i = 1; i < this._blocks.Count; i++)
            {
                Block b = (Block)this._blocks[i];
                if (head.Point.X == b.Point.X && head.Point.Y == b.Point.Y)
                {
                    return true;
                }
            }
            return false;
        }

        
        private Block getFood()
        {
            Block food = null;
            Random r = new Random();
            bool redo = false;
            while (true)
            {
                redo = false;
                int x = r.Next(this._width);
                int y = r.Next(this._height);
                for (int i = 0; i < this._blocks.Count; i++)
                {
                    Block b = (Block)(this._blocks[i]);
                    if (b.Point.X == x && b.Point.Y == y)
                    { redo = true; }
                }
                if (redo == false)
                {
                    food = new Block(Color.Red,  this._size, new Point(x, y));
                    break;
                }
            }
            return food;
        }

        
        private void move()
        {
            Point p;
            Block head = (Block)this._blocks[0];
            if (this._direction == Direction.Up)
                p = new Point(head.Point.X, head.Point.Y - 1);
            else if (this._direction == Direction.Down)
                p = new Point(head.Point.X, head.Point.Y + 1);
            else if (this._direction == Direction.Left)
                p = new Point(head.Point.X - 1, head.Point.Y);
            else
                p = new Point(head.Point.X + 1, head.Point.Y);

           
            Block b = new Block(Color.Green, this._size, p);

            
            if (this._food.Point != p)
                this._blocks.RemoveAt(this._blocks.Count - 1);

           
            else
                this._food = this.getFood();
            this._blocks.Insert(0, b);
            scoreLable.Invoke(new Action(() => scoreLable.Text = _blocks.Count.ToString()));
            this.PaintPalette(this._gpPalette);


        }

        
        public void PaintPalette(Graphics gp)
        {
            gp.Clear(this._bgColor);
            this._food.Paint(gp);
            foreach (Block b in this._blocks)
                b.Paint(gp);
        }
       

    }
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }





}

