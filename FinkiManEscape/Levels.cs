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
            int count =Resources.levels.Split(' ').Length;
            string[] strings = new string[count];
            strings = Resources.levels.Split(' ');
            Figura[] figuri = new Figura[count];
            int numbs;
            if (Int32.TryParse(strings[0], out numbs))
            {

                figuri[0] = new Student(numbs % 10, (numbs /= 10) % 10, (numbs /= 10) % 10, (numbs /= 10) % 10, (numbs /= 10) % 10);
            }
            for (int i = 1; i < count; i++)
            {
                if (Int32.TryParse(strings[i], out numbs))
                {

                    figuri[i] = new Blocks(numbs % 10, (numbs /= 10) % 10, (numbs /= 10) % 10, (numbs /= 10) % 10);
                }
            }
            levels.Add(new Level(figuri));
        }

        public Level this[int key]
        {
            get
            {
                return levels.ElementAt(key);
            }
        }

        public void add(Level level)
        {
            levels.Add(level);
        }
    }
}
