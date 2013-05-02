using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiManEscape
{
    class Figura
    {
        public int Length { get; set; }//kolko kocke da zafati

        public int PositionX { get; set; }//pozicija kude pocnue figura(kolona)
        public int PositionY { set; get; }//pozicija kude pocnue figura(red)

        public int Orinetation { get; set; }//ovoj e jasno :P
        static readonly int PORTRAIT = 0;
        static readonly int LANDSCAPE = 1;
        
        public int[] Bounds { set; get; }//Slobodni kocke bounds[0]:UP bounds[1]:DOWN...
        static readonly int BOUNDUP = 0;
        static readonly int BOUNDDOWN = 1;
        static readonly int BOUNDLEFT = 2;
        static readonly int BOUNDRIGHT = 3;

        public Figura(int lenth, int positionX, int positionY, int orientation)
        {
            Length = lenth;
            PositionX = positionX;
            PositionY = positionY;
            Orinetation = orientation;
            Bounds = new int[4];
        }

        public bool move(int moveLenth)
        {
            if (Orinetation == PORTRAIT)
            {
                //ispitaj dali e do kraj
                PositionY += moveLenth;
            }
            else
            {
                //ispitaj granice
                PositionX += moveLenth;
            }
            return true;
        }

        public void adjust()
        {
            //pri mouseUp treba da gu namesti figuru na mesto
        }

        public void draw(Graphics g)
        {
            //iscrtaj figuru
        }
       
    }
}
