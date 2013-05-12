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
        Image slika;
        bool male;

        public Student(int length, int positionX, int positionY, int orientation, bool male):base (length, positionX, positionY, orientation)
        {
            this.male = male;
            if (this.male)
            {
                this.slika = Resources.finki;
            }
            else this.slika = Resources.pou;
        }
    }
}
