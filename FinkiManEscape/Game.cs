using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinkiManEscape
{
    class Game
    {
        private Figura[] figuri;

        public int[][] Grid;//koja kocka e slobodna a koja ne 6x6
        public static readonly int EMPTYSQUARE = -1;//flag za praznu kocku a drugi ke se oznacuev po redan broj od objekt sto dovadjav 1 za figura[1], 2 za figura[2]...

        public static readonly int squareDimension = 100;//pikseli za duzinu i sirinu na ednu kocku

        public Game(Figura[] figuri)
        {
            for (int i = 0; i < figuri.Length; i++)
            {
                this.figuri[i] = figuri[i];
            }
            initializeGrid();
        }

        public void initializeGrid()
        {
            Grid = new int[6][];
            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = new int[6];
            }
            //potpuni ga Grid prazni puni kocke...
        }
    }
}
