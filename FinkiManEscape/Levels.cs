using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinkiManEscape.Properties;

namespace FinkiManEscape
{
    class Levels
    {
        public List<Level> levels;

        public Levels()
        {
            levels = new List<Level>();
            int count =Resources.levels.Split('\n').Length;
           
            string[] lines = new string[count];
            lines = Resources.levels.Split('\n');
            foreach (string line in lines)
            {
                int c = line.Split(' ').Length;
                Figura[] figuri = new Figura[c];
                string[] element = new string[c];
                element = line.Split(' ');

                int numbs;
                if (Int32.TryParse(element[0], out numbs))
                {
                    figuri[0] = new Student(numbs / 10000, (numbs % 10000) / 1000, (numbs % 1000) / 100, (numbs % 100) / 10, (numbs % 10) == 0);
                }
                
                for (int i = 1; i < count; i++)
                {
                    if (Int32.TryParse(element[i], out numbs))
                    {
                        figuri[i] = new Blocks(numbs / 1000, (numbs % 1000) / 100, (numbs % 100) / 10, numbs % 10);
                    }
                }
                levels.Add(new Level(figuri));
            }
            
        }

        public Level this[int key]
        {
            get
            {
                return levels[key];
            }
        }

        public void add(Level level)
        {
            levels.Add(level);
        }
    }
}
