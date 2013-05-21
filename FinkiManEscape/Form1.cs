using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using FinkiManEscape.Properties;


namespace FinkiManEscape
{
    public partial class Form1 : Form
    {
        
        Game game;
        int dX, dY;
        bool moving;
        Timer animationFinish;
        Door door;
        private Point[] points, points2;
        Levels levels;
        public Form1()
        {
            InitializeComponent();
            Figura f1 = new Blocks(2, 2, 0, Figura.PORTRAIT);
            Figura f2 = new Blocks(2, 0, 1, Figura.LANDSCAPE);
            Figura f3 = new Blocks(2, 0, 2, Figura.PORTRAIT);
            Figura f4 = new Student(2, 1, 2, Figura.LANDSCAPE,true);
            //Figura f5 = new Blocks(2, 1, 3, Figura.PORTRAIT);
            //Figura f6 = new Blocks(2, 2, 4, Figura.LANDSCAPE);
            //Figura f7 = new Blocks(2, 3, 1, Figura.PORTRAIT);
            //Figura f8 = new Blocks(3, 3, 0, Figura.LANDSCAPE);
            //Figura f9 = new Blocks(3, 4, 2, Figura.PORTRAIT);
            //Figura f10 = new Blocks(2, 3, 5, Figura.LANDSCAPE);
            //Figura f11 = new Blocks(2, 5, 1, Figura.PORTRAIT);
            //Figura f12 = new Blocks(2, 5, 3, Figura.PORTRAIT);
            Figura[] f = new Figura[4];
            f[0] = f1;
            f[1] = f2;
            f[2] = f3;
            f[3] = f4;
            //f[4] = f5;
            //f[5] = f6;
            //f[6] = f7;
            //f[7] = f8;
            //f[8] = f9;
            //f[9] = f10;
            //f[10] = f11;
            //f[11] = f12;
            //game = new Game(f);
            levels = new Levels();
            game = new Game(levels[0]);
            dX = dY = 0;
            moving = false;
          
            DoubleBuffered = true;
            animationFinish = new Timer();
            animationFinish.Interval = 5;
            animationFinish.Tick += new EventHandler(animationFinish_Tick);
            initializePoints();
        }

        private void initializePoints()
        {
            door = new Door(6 * Game.squareDimension + Figura.paddingX * 2, Figura.paddingY + 2 * Game.squareDimension - Game.squareDimension / 2, Game.squareDimension, Game.squareDimension);
            points = new Point[8];
            points[0] = new Point(6*Game.squareDimension + 2 * Figura.paddingX, menuStrip1.Height);
            points[1] = new Point(6*Game.squareDimension + 2 * Figura.paddingX + 2*Game.squareDimension, menuStrip1.Height);
            points[2] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX + 2*Game.squareDimension, 6 * Game.squareDimension + Figura.paddingY + 3*Game.squareDimension/2);
            points[3] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 6 * Game.squareDimension + Figura.paddingY + menuStrip1.Height);
            points[4] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 3 * Game.squareDimension + Figura.paddingY);
            points[5] = new Point(7 * Game.squareDimension + Figura.paddingX, 3 * Game.squareDimension + Figura.paddingY);
            points[6] = new Point(7 * Game.squareDimension + Figura.paddingX, 2 * Game.squareDimension + Figura.paddingY);
            points[7] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 2 * Game.squareDimension + Figura.paddingY);
            points2 = new Point[4];
            points2[0] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 6 * Game.squareDimension + Figura.paddingY+10);
            points2[1] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX + 2 * Game.squareDimension, 6 * Game.squareDimension + Figura.paddingY + 3 * Game.squareDimension / 2);
            points2[2] = new Point(0, 6 * Game.squareDimension + Figura.paddingY + 3 * Game.squareDimension / 2);
            points2[3] = new Point(0, 6 * Game.squareDimension + Figura.paddingY+10);

        }

        void animationFinish_Tick(object sender, EventArgs e)
        {

            if (door.opening() || game.drawFinish())
            {
                Invalidate();
            }
            else
            {
                animationFinish.Stop();
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!game.prepareMove(e.X, e.Y))
            {
                return;
            }
            dX = e.X;
            dY = e.Y;
            moving = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                int dy, dx;
                dx = e.X - dX;
                dy = (e.Y - dY);
                dX = e.X;
                dY = e.Y;
                if (game.moveCurrent(dx, dy))
                {
                    Invalidate();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                while (game.adjust())
                {
                    Invalidate();
                }
                if (game.endGame())
                {
                   animationFinish.Start();
                }
                else
                    game.finishMove();
                moving = false;
            }
            dX = dY = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.grid, new Rectangle(0, this.menuStrip1.Height, 6 * Game.squareDimension + 2 * Figura.paddingX, 6 * Game.squareDimension + menuStrip1.Height));
            game.draw(e.Graphics);
            e.Graphics.FillPolygon(new SolidBrush(Color.SandyBrown), points);
            e.Graphics.FillPolygon(new SolidBrush(Color.BurlyWood), points2);
            door.draw(e.Graphics);
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.squareDimension = 30;
            initializePoints();
            Figura.gap = 1;
            game.reSize();
            this.Height = 285;
            this.Width = 265;
            Invalidate();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.squareDimension = 60;
            initializePoints();
            Figura.gap = 2;
            game.reSize();
            this.Height = 510;
            this.Width = 505;
            Invalidate();
        }

        private void bigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.squareDimension = 100;
            initializePoints();
            Figura.gap = 4;
            game.reSize();
            this.Height = 780;
            this.Width = 770;
            Invalidate();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           int cmd= Height;
           cmd= Width;
        }

    }
}
