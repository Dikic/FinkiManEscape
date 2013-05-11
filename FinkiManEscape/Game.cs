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
            //------brisi ovoj posle
            figuri[3].brush = new SolidBrush(Color.Red);
            //------------------------------------------
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
            if (x < Grid.Length * squareDimension && y < Grid.Length * squareDimension)
            {
                CurrentActive = Grid[x / squareDimension][y / squareDimension];
            }
            if (CurrentActive != -1) 
            {
                updateBounds();
                figuri[CurrentActive].PositionX *= squareDimension;
                figuri[CurrentActive].PositionY *= squareDimension;
                return true;
            }
            else return false;
            

        }

        private void updateBounds()
        {
            if (figuri[CurrentActive].Orinetation == Figura.LANDSCAPE)
            {
                int begin = figuri[CurrentActive].PositionX;
                int Y = figuri[CurrentActive].PositionY;
                int br = 0;
                while (begin != 0)
                {
                    if (Grid[begin - 1][Y] == EMPTYSQUARE) br++;
                    else break;
                    begin--;
                }
                figuri[CurrentActive].Bounds[Figura.BOUNDLEFT] = (figuri[CurrentActive].PositionX - br) * Game.squareDimension;

                begin = figuri[CurrentActive].PositionX + figuri[CurrentActive].Length-1;
                br = 0;
                begin++;
                while (begin != Grid.Length)
                {
                    if (Grid[begin][Y] == EMPTYSQUARE) br++;
                    else break;
                    begin++;
                }
                figuri[CurrentActive].Bounds[Figura.BOUNDRIGHT] = (br + figuri[CurrentActive].PositionX + figuri[CurrentActive].Length) * Game.squareDimension;
            }
            else
            {
                int begin = figuri[CurrentActive].PositionY;
                int X = figuri[CurrentActive].PositionX;
                int br = 0;
                while (begin != 0)
                {
                    if (Grid[X][begin - 1] == EMPTYSQUARE) br++;
                    else break;
                    begin--;
                }
                figuri[CurrentActive].Bounds[Figura.BOUNDUP] = (figuri[CurrentActive].PositionY-br) * Game.squareDimension;

                begin = figuri[CurrentActive].PositionY + figuri[CurrentActive].Length-1;
                br = 0;
                begin++;
                while (begin != Grid.Length)
                {
                    if (Grid[X][begin] == EMPTYSQUARE) br++;
                    else break;
                    begin++;
                }
                figuri[CurrentActive].Bounds[Figura.BOUNDDOWN] = (br + figuri[CurrentActive].PositionY + figuri[CurrentActive].Length) * Game.squareDimension;
            }
        }
        /// <summary>
        /// Zavrsuvanje na move obavezno pri mouse up
        /// </summary>
        public void finishMove()
        {
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

        public bool adjust()
        {
            if (figuri[CurrentActive].Orinetation == Figura.PORTRAIT)
            {
                int t = figuri[CurrentActive].PositionY % 100;
                if (t == 0) return false;
                else
                    if (t < 50) figuri[CurrentActive].move(0,-1);
                    else figuri[CurrentActive].move(0,1);
            }
            else
            {
                int t = figuri[CurrentActive].PositionX % 100;
                if (t == 0) return false;
                else
                    if (t < 50) figuri[CurrentActive].move(-1, 0);
                    else figuri[CurrentActive].move(1, 0);
            }
            return true;
        }

        
    }
}
