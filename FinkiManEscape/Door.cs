using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FinkiManEscape.Properties;

namespace FinkiManEscape
{
    /// <summary>
    /// Klasata za vrati koi se otvaraat na krajot na levelot.
    /// </summary>
    class Door
    {
        private Rectangle doorUp, doorDown;
        private Image imgDoorUp, imgDoordown;
        private int X, Yup, Ydown, height, width;

        /// <summary>
        /// Konstruktor za klasata "Door"
        /// </summary>
        /// <param name="X">X koordinara vo odnos na formata vo koja e.</param>
        /// <param name="Y">Y koordinara vo odnos na formata vo koja e.</param>
        /// <param name="width">Sirina vo pikseli</param>
        /// <param name="height">Golemina vo pikseli</param>
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

        /// <summary>
        /// Metoda so koja se otvaraat vrati
        /// </summary>
        /// <returns>Vraka true - se otvaraat, false - vratata e otvorena </returns>
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
        /// <summary>
        /// Metoda za iscrtuvanje
        /// </summary>
        /// <param name="g">Grafickiot kontekst na formata</param>
        public void draw(Graphics g)
        {
            g.DrawImage(imgDoorUp, doorUp);
            g.DrawImage(imgDoordown, doorDown);
        }
        
    }
}
