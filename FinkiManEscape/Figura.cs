using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiManEscape
{
    class Figura
    {
        private Rectangle rec;
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
            rec = new Rectangle(X, Y, width, heigth);
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
                //ispitaj dali e do kraj
               // if (PositionY + Y > Bounds[BOUNDDOWN] * Game.squareDimension || PositionY + Y < Bounds[BOUNDUP] * Game.squareDimension)
              //  {
                 //   return false; //nadvor od granici
               // }
                PositionY += Y;//razlikaod poslednjo
                rec = new Rectangle(PositionX, PositionY, Game.squareDimension, Length * Game.squareDimension);
            }
            else
            {
                //ispitaj granice
                //RAZRABOTI GA ZA BOUNDS
              //  if (PositionX + X > Bounds[BOUNDRIGHT] * Game.squareDimension || PositionY + Y < Bounds[BOUNDLEFT] * Game.squareDimension)
               // {
               //     return false; //nadvor od granici
               // }
                PositionX += X;
                rec = new Rectangle(PositionX, PositionY, Length * Game.squareDimension, Game.squareDimension);
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
            Random rnd=new Random();
          
            g.FillRectangle(brush, rec);
        }
       
    }
}
