using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinkiManEscape
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();           
            Figura f1=new Figura(2, 0, 0, Figura.PORTRAIT);
            Figura f2=new Figura(3, 2, 1, Figura.LANDSCAPE);
            List<Figura> figuri = new List<Figura>();
            figuri.Add(f1);
            figuri.Add(f2);
            game = new Game(figuri);            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            game.prepareMove(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.moveCurrent(e.X, e.Y))
            {
                Invalidate();
            }
           
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            game.finishMove();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.draw(e.Graphics);
        }


    }
}
