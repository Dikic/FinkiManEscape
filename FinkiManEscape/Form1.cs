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
            game.finisMove();
        }


    }
}
