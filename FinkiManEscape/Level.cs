using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinkiManEscape
{
    public class Level
    {
        public int LevelId { get; set; }
        public virtual Levels Levels { get; set; }

        public Figura[] figuri { get; set; }

        public int LevelNumber { get; set; }
        private int time;
        private int moves;
        public int Time { get { return time; } set { if (value < time)time = value; } }
        public int Moves { get { return time; } set { if (value < moves) moves = value; } }
        public int Length { get { return figuri.Length; } }

        public bool Finished { get; set; }

        

        public Level(Figura[] figuri)
        {
            time = 0;
            moves = 0;
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
        public override string ToString()
        {
            return string.Format("Level {0} | Best time {1}:{2} | Best moves {3}", LevelNumber, time / 60, time % 60, moves);
        }
    }
}
