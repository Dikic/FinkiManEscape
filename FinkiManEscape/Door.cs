using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FinkiManEscape.Properties;

namespace FinkiManEscape
{
    class Door
    {
        private Rectangle doorUp, doorDown;
        private Image imgDoorUp, imgDoordown;
        private int X, Yup, Ydown, height, width;

        public Door(int X, int Y, int width, int height)
        {
            this.height = height;
            this.width = width;

            this.X = X;
            Yup = Y + height;
            doorUp = new Rectangle(X, Yup, width, height);
            
            Ydown = Y;
            doorDown = new Rectangle(X, Ydown, width, height);
            imgDoorUp = Resources.rightDoor;
            imgDoordown = Resources.leftDoor;
        }

        public bool opening()
        {
            if (Yup - Ydown >= 2 * height) return false;
            else
            {
                Ydown--;
                Yup++;
                doorUp = new Rectangle(X, Yup, width, height);
                doorDown = new Rectangle(X, Ydown, width, height);
            }
            return true;
        }
        public void draw(Graphics g)
        {
            g.DrawImage(imgDoorUp, doorUp);
            g.DrawImage(imgDoordown, doorDown);
        }
        
    }
}
