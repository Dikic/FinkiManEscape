using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinkiManEscape
{
    class Game
    {
        public Level level { get; set; }
        
        public int[][] Grid;//koja kocka e slobodna a koja ne 6x6
        public static readonly int EMPTYSQUARE = -1;//flag za praznu kocku a drugi ke se oznacuev po redan broj od objekt sto dovadjav 1 za figura[1], 2 za figura[2]...

        public static int squareDimension = 100;//pikseli za duzinu i sirinu na ednu kocku

        public int CurrentActive { set; get; }//momentalno aktivna figura za pomestuvanje
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="level">niza od objekti od level</param>
        public Game(Figura[] figuri)
        {
            level = new Level(figuri);

            initializeGrid();
            CurrentActive = EMPTYSQUARE;
            //------brisi ovoj posle
            level[3].brush = new SolidBrush(Color.Red);
            //------------------------------------------
        }

        public Game(Level level)
        {
            this.level = level;
            initializeGrid();
            CurrentActive = EMPTYSQUARE;
        }
        public void initializeGrid()
        {
            
            //potpuni ga Grid prazni, puni kocke...
            updateGrid();
        }

        public void updateGrid()
        {
            Grid = new int[6][];
            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = new int[6];
            }
            for (int i = 0; i < Grid.Length; i++)//inicijaliziraj na prazni
            {
                for (int j = 0; j < Grid[i].Length; j++)
                {
                    Grid[i][j] = EMPTYSQUARE;
                }
            }

            for (int j = 0; j < level.Length; j++)//projdi gi site level
            {
                for (int i = 0; i < level[j].Length; i++)//za sekoja figura prejdi kolko prazni kocke ima za obelezuvanje
                {

                    if (level[j].Orinetation == Figura.PORTRAIT)
                    {
                        Grid[level[j].PositionX][level[j].PositionY + i] = j;//ako e portrait se oznacuvaat po y-oska (positionX i positionY se pocetni kocki)
                    }
                    else
                    {
                        Grid[level[j].PositionX + i][level[j].PositionY] = j;
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
            if (x < Grid.Length * squareDimension + Figura.paddingX && y < Grid.Length * squareDimension + Figura.paddingY)
            {
                CurrentActive = Grid[(x - Figura.paddingX) / squareDimension][(y - Figura.paddingY) / squareDimension];
            }
            if (CurrentActive != -1) 
            {
                updateBounds();
                level[CurrentActive].PositionX *= squareDimension;
                level[CurrentActive].PositionY *= squareDimension;
                return true;
            }
            else return false;
            

        }

        private void updateBounds()
        {
            if (level[CurrentActive].Orinetation == Figura.LANDSCAPE)
            {
                int begin = level[CurrentActive].PositionX;
                int Y = level[CurrentActive].PositionY;
                int br = 0;
                while (begin != 0)
                {
                    if (Grid[begin - 1][Y] == EMPTYSQUARE) br++;
                    else break;
                    begin--;
                }
                level[CurrentActive].Bounds[Figura.BOUNDLEFT] = (level[CurrentActive].PositionX - br) * Game.squareDimension;

                begin = level[CurrentActive].PositionX + level[CurrentActive].Length-1;
                br = 0;
                begin++;
                while (begin != Grid.Length)
                {
                    if (Grid[begin][Y] == EMPTYSQUARE) br++;
                    else break;
                    begin++;
                }
                level[CurrentActive].Bounds[Figura.BOUNDRIGHT] = (br + level[CurrentActive].PositionX + level[CurrentActive].Length) * Game.squareDimension;
            }
            else
            {
                int begin = level[CurrentActive].PositionY;
                int X = level[CurrentActive].PositionX;
                int br = 0;
                while (begin != 0)
                {
                    if (Grid[X][begin - 1] == EMPTYSQUARE) br++;
                    else break;
                    begin--;
                }
                level[CurrentActive].Bounds[Figura.BOUNDUP] = (level[CurrentActive].PositionY-br) * Game.squareDimension;

                begin = level[CurrentActive].PositionY + level[CurrentActive].Length-1;
                br = 0;
                begin++;
                while (begin != Grid.Length)
                {
                    if (Grid[X][begin] == EMPTYSQUARE) br++;
                    else break;
                    begin++;
                }
                level[CurrentActive].Bounds[Figura.BOUNDDOWN] = (br + level[CurrentActive].PositionY + level[CurrentActive].Length) * Game.squareDimension;
            }
        }
        /// <summary>
        /// Zavrsuvanje na move obavezno pri mouse up
        /// </summary>
        public void finishMove()
        {
            level[CurrentActive].PositionX /= squareDimension;
            level[CurrentActive].PositionY /= squareDimension;
            updateGrid();
        }

        public bool moveCurrent(int X, int Y)
        {
            if (CurrentActive != EMPTYSQUARE)
            {
                if (!level[CurrentActive].move(X, Y)) return false;
                
            }
            return true;
        }

        public void draw(Graphics g)
        {
            foreach (Figura f in level.figuri)
            {
                f.draw(g);
            }

        }

        public bool adjust()
        {
            if (level[CurrentActive].Orinetation == Figura.PORTRAIT)
            {
                int t = level[CurrentActive].PositionY % squareDimension;
                if (t == 0) return false;
                else
                    if (t < 50) level[CurrentActive].move(0,-1);
                    else level[CurrentActive].move(0,1);
            }
            else
            {
                int t = level[CurrentActive].PositionX % squareDimension;
                if (t == 0) return false;
                else
                    if (t < 50) level[CurrentActive].move(-1, 0);
                    else level[CurrentActive].move(1, 0);
            }
            return true;
        }



        public bool endGame()
        {
            return level[CurrentActive].endGame();
        }

        public bool drawFinish()
        {
            int t = 6 * Game.squareDimension + Figura.paddingY - level[CurrentActive].PositionX + Figura.paddingY;
            if (t == 0) return false;
            else
            {
                level[CurrentActive].PositionX++;
                level[CurrentActive].rec = new Rectangle(level[CurrentActive].PositionX + Figura.gap + Figura.paddingX, level[CurrentActive].PositionY + Figura.gap + Figura.paddingY, level[CurrentActive].Length * Game.squareDimension - Figura.gap, Game.squareDimension - Figura.gap);
            }
            return true;
        }
        public void reSize()
        {
            foreach (Figura f in level.figuri)
            {
                f.resize();
            }
        }
    }
}
