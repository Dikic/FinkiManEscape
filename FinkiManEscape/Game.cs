using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiManEscape
{
    class Game
    {
        private Figura[] figuri;
        
        public int[][] Grid;//koja kocka e slobodna a koja ne 6x6
        public static readonly int EMPTYSQUARE = -1;//flag za praznu kocku a drugi ke se oznacuev po redan broj od objekt sto dovadjav 1 za figura[1], 2 za figura[2]...

        public static readonly int squareDimension = 100;//pikseli za duzinu i sirinu na ednu kocku

        public int CurrentActive { set; get; }//momentalno aktivna figura za pomestuvanje
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="figuri">niza od objekti od figuri</param>
        public Game(Figura[] figuri)
        {
            this.figuri = new Figura[figuri.Length];
            for (int i = 0; i < figuri.Length; i++)
           {
              this.figuri[i] = figuri[i];
            }
            
            initializeGrid();
            CurrentActive = EMPTYSQUARE;
        }

        public void initializeGrid()
        {
            Grid = new int[6][];
            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = new int[6];
            }
            //potpuni ga Grid prazni, puni kocke...
            updateGrid();
        }

        public void updateGrid()
        {
            for (int i = 0; i < Grid.Length; i++)//inicijaliziraj na prazni
            {
                for (int j = 0; j < Grid[i].Length; j++)
                {
                    Grid[i][j] = EMPTYSQUARE;
                }
            }

            for (int j = 0; j < figuri.Length; j++)//projdi gi site figuri
            {
                for (int i = 0; i < figuri[j].Length; i++)//za sekoja figura prejdi kolko prazni kocke ima za obelezuvanje
                {

                    if (figuri[j].Orinetation == Figura.PORTRAIT)
                    {
                        Grid[figuri[j].PositionX][figuri[j].PositionY + i] = j;//ako e portrait se oznacuvaat po y-oska (positionX i positionY se pocetni kocki)
                    }
                    else
                    {
                        Grid[figuri[j].PositionX + i][figuri[j].PositionY] = j;
                    }
                }
            }
        }
        /// <summary>
        /// Priprema za move t.e. postavuvanje na vistinskite PositionX i PositionY
        /// </summary>
        /// <param name="x">x-koordinata na poleto</param>
        /// <param name="y">y koordinata</param>
        public bool prepareMove(int x, int y)
        {
            for (int i = 0; i < Grid.Length; i++)
            {
                bool isBreak = false;
                for (int j = 0; j < Grid[i].Length; j++)
                {
                    if (x > i * squareDimension && x < (i + 1) * squareDimension)
                    {
                        if (y > j * squareDimension && y < (j + 1) * squareDimension)
                        {
                            CurrentActive = Grid[i][j];
                            isBreak = true;
                            break;
                        }
                    }
                }
                if (isBreak) break;
                
            }
            if (CurrentActive != -1) 
            {
                figuri[CurrentActive].PositionX *= squareDimension;
                figuri[CurrentActive].PositionY *= squareDimension;
                return true;
            }
            else return false;
            

        }
        /// <summary>
        /// Zavrsuvanje na move obavezno pri mouse up
        /// </summary>
        public void finishMove()
        {
            figuri[CurrentActive].adjust();
            figuri[CurrentActive].PositionX /= squareDimension;
            figuri[CurrentActive].PositionY /= squareDimension;
            CurrentActive = EMPTYSQUARE;
            updateGrid();
        }
        public bool moveCurrent(int X, int Y)
        {
            if (CurrentActive != EMPTYSQUARE)
            {
                if (!figuri[CurrentActive].move(X, Y)) return false;
                //da se dopuni i provadjanje niz svi draw metode ss for
            }
            return true;
        }

        public void draw(Graphics g)
        {
            foreach (Figura f in figuri)
            {
                f.draw(g);
            }

        }
    }
}
