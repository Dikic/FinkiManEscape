using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FinkiManEscape.Properties;


namespace FinkiManEscape
{
    class Student: Figura
    {
        Image image;
        bool male;

        public Student(int length, int positionX, int positionY, int orientation, bool male):base (length, positionX, positionY, orientation)
        {
            this.male = male;
            if (this.male)
            {
                this.image = Resources.boywithbook;
            }
            else this.image = Resources.girlwithbook;
        }

        public override void draw(Graphics g)
        {
            g.DrawImage(image, this.rec);
        }
        public override bool endGame()
        {
            if (PositionX + Length*Game.squareDimension == 6*Game.squareDimension) return true;
            return false;
        }
    }
}
