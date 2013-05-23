using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinkiManEscape.Properties;

namespace FinkiManEscape
{
    public class Levels
    {
        public int LevelsId { get; set; }
        public List<Level> Level;
        public Level OriginalCurrentLevel
        {
            get
            {
                string line = Resources.levels.Split('\n')[CurrentLevel];
                int c = line.Split(' ').Length;
                Figura[] figuri = new Figura[c];
                string[] element = new string[c];
                element = line.Split(' ');

                int numbs;
                if (Int32.TryParse(element[0], out numbs))
                {
                    Student s = new Student(numbs / 1000, (numbs % 1000) / 100, (numbs % 100) / 10, numbs % 10); 
                    s.Male = Male;
                    figuri[0] = s;
                } for (int j = 1; j < c; j++)
                {
                    if (Int32.TryParse(element[j], out numbs))
                    {
                        figuri[j] = new Blocks(numbs / 1000, (numbs % 1000) / 100, (numbs % 100) / 10, numbs % 10);
                    }
                }
                Level level = new Level(figuri);
                level.LevelNumber = CurrentLevel;
                return level;
            }

        }
        public int Count { get; set; }
        public int CurrentLevel { get; set; }
        private bool male;

        public bool Male
        {
            get { return male; }
            set
            {
                male = value;
                foreach (Level lev in Level)
                {
                    (lev.figuri[0] as Student).Male = value;
                }
            }
        }

        public Levels(bool male)
        {
            CurrentLevel = 0;
            Level = new List<Level>();
            Male = male;
            int count =Resources.levels.Split('\n').Length;
           
            string[] lines = new string[count];
            lines = Resources.levels.Split('\n');

            for (int i = 0; i < count; i++)
            {
                int c = lines[i].Split(' ').Length;
                Figura[] figuri = new Figura[c];
                string[] element = new string[c];
                element = lines[i].Split(' ');

                int numbs;
                if (Int32.TryParse(element[0], out numbs))
                {
                    Student s= new Student(numbs / 1000, (numbs % 1000) / 100, (numbs % 100) / 10, numbs % 10);
                    s.Male=male;
                    figuri[0] = s;
                }
                
                for (int j = 1; j < c; j++)
                {
                    if (Int32.TryParse(element[j], out numbs))
                    {
                        figuri[j] = new Blocks(numbs / 1000, (numbs % 1000) / 100, (numbs % 100) / 10, numbs % 10);
                    }
                }
                Level level = new Level(figuri);
                level.LevelNumber = i;
                Level.Add(level);
            }
            Count = count;
        }

        public Level this[int key]
        {
            get
            {
                return Level[key];
            }
        }

        public void add(Level level)
        {
            Level.Add(level);
        }

        public Level getCurrentLevel()
        {
            return Level[CurrentLevel];
        }

        public void nextLevel()
        {
            CurrentLevel++;
            CurrentLevel %= Count;
        }
    }
}
