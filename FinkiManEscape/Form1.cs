using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FinkiManEscape
{
    public partial class Form1 : Form
    {
        Game game;
        int dX, dY;
        bool moving;
        public Form1()
        {
            InitializeComponent();           
            Figura f1=new Figura(2, 0, 0, Figura.PORTRAIT);
            Figura f2=new Figura(3, 2, 1, Figura.LANDSCAPE);
            Figura[] f = new Figura[2];
            f[0] = f1;
            f[1] = f2;
            game = new Game(f);
            dX = dY = 0;
            moving = false;    
            
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
                //u for gu povikuesh Game.adjust i se pravi invalidate 
                game.finishMove();
                moving = false;
            }
            dX = dY = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.draw(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, 600, 600));
        }
        

    }
}
