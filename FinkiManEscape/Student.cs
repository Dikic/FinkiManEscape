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
        private bool male;
        public bool Male { get { return male; } set { male = value; if (!male)this.image = Resources.girlwithbook; } }
       
        public Student(int length, int positionX, int positionY, int orientation):base (length, positionX, positionY, orientation)
        {
            this.male = true;
            this.image = Resources.boywithbook;
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
