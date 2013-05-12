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
                this.image = Resources.finki;
            }
            else this.image = Resources.pou;
        }

        public override void draw(Graphics g)
        {
            g.DrawImage(image, this.rec);
        }
        public override bool endGame()
        {
            //implementacija
            return false;
        }
    }
}
