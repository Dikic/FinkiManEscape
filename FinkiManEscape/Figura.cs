using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiManEscape
{
    abstract class Figura
    {
        public Rectangle rec;
        public Brush brush;
        public int Length { get; set; }//kolko kocke da zafati

        public int PositionX { get; set; }//pozicija kude pocnue figura(kolona)
        public int PositionY { set; get; }//pozicija kude pocnue figura(red)

        public int X { get; set; }
        public int Y { get; set; }

        public int Orinetation { get; set; }//ovoj e jasno :P
        public static readonly int PORTRAIT = 0;
        public static readonly int LANDSCAPE = 1;
        
        public int[] Bounds { set; get; }//Slobodni kocke bounds[0]:UP bounds[1]:DOWN...
        public static readonly int BOUNDUP = 0;
        public static readonly int BOUNDDOWN = 1;
        public static readonly int BOUNDLEFT = 0;
        public static readonly int BOUNDRIGHT = 1;

        public int gap { set; get; }
        public Figura(int length, int positionX, int positionY, int orientation)
        {
            X = positionX * Game.squareDimension;
            Y = positionY * Game.squareDimension;
            int width, heigth;
            if (orientation == PORTRAIT)
            {
                heigth = length * Game.squareDimension;
                width = Game.squareDimension;
            }
            else
            {
                width = length * Game.squareDimension;
                heigth = Game.squareDimension;
            }
            gap = 4;
            rec = new Rectangle(X + gap, Y + gap, width - gap, heigth - gap);
            brush = new SolidBrush(Color.Aquamarine);
            Length = length;
            PositionX = positionX;
            PositionY = positionY;
            Orinetation = orientation;
            Bounds = new int[2];
        }

        public bool move(int X, int Y)
        {
            if (Orinetation == PORTRAIT)
            {
                if (PositionY + Y < Bounds[BOUNDUP] || PositionY + Y + Length * Game.squareDimension > Bounds[BOUNDDOWN])
                {
                    return false;
                }
                PositionY += Y;//razlikaod poslednjo
                rec = new Rectangle(PositionX + gap, PositionY + gap, Game.squareDimension - gap, Length * Game.squareDimension - gap);
            }
            else
            {
                if (PositionX + X < Bounds[BOUNDLEFT] || PositionX + X + Length * Game.squareDimension > Bounds[BOUNDRIGHT])
                {
                    return false;
                }
                PositionX += X;
                rec = new Rectangle(PositionX + gap, PositionY + gap, Length * Game.squareDimension - gap, Game.squareDimension - gap);
            }
            return true;
        }

        virtual public void draw(Graphics g)
        {
           
        }
       
    }
}
