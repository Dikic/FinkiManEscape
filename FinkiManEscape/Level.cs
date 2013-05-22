using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinkiManEscape
{
    public class Level
    {
        public int LevelNumber { get; set; }

        public virtual Levels Levels { get; set; }

        public Figura[] figuri { get; set; }

        public int Length { get { return figuri.Length; } }

        public bool Finished { get; set; }

        public int LevelId { get; set; }

        public Level(Figura[] figuri)
        {
            this.figuri = new Figura[figuri.Length];
            for (int i = 0; i < figuri.Length; i++)
            {
                this.figuri[i] = figuri[i];
            }
            Finished = false;
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
