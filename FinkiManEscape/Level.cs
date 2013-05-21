using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinkiManEscape
{
    class Level
    {
        public int LevelNumber { get; set; }

        public Figura[] figuri;

        public int Length { get { return figuri.Length; } }

        public Level(Figura[] figuri)
        {
            this.figuri = new Figura[figuri.Length];
            for (int i = 0; i < figuri.Length; i++)
            {
                this.figuri[i] = figuri[i];
            }
            
        }

        public Figura this[int key]
        {
            get
            {
                return figuri[key];
            }

            set
            {
                figuri[key] = value;
            }
        }
    }
}
