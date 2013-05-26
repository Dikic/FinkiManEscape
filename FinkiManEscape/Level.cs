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
        public int Time
        {
            get { return time; }
            set { if (value < time || time == -1)time = value; }
        }
        public int Moves
        {
            get { return moves; }
            set { if (value < moves || moves == -1) moves = value; }
        }
        public int Length { get { return figuri.Length; } }

        public bool Finished { get; set; }

        

        public Level(Figura[] figuri)
        {
            Time = -1;
            Moves = -1;
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
            if (time == -1)
            {
                return string.Format("Level {0} \nBest time --:-- \nBest moves --", LevelNumber + 1);
            }
            return string.Format("Level {0} \nBest time {1:00}:{2} \nBest moves {3}", LevelNumber + 1, time / 60, time % 60, moves);
        }
    }
}
