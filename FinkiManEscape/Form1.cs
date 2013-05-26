using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using FinkiManEscape.Properties;
using System.Media;


namespace FinkiManEscape
{
    
    public partial class Form1 : Form
    {
        
        Game game;
        int dX, dY;
        bool moving;
        Timer animationFinish, levelTimer;
        Door door;
        private Point[] points, points2;
        Levels levels;

        Rectangle timeRect;
        int FontSize;
        int movesPerLevel;
        int timePerLevel;
        int pauseTime, pauseMoves;
        bool paused;
        
        public bool mainWindow { get; set; }
        /// <summary>
        /// Golemina na ekran
        /// </summary>
        public enum WindowTypeSize
        {
            small,
            medium,
            big
        }
        public WindowTypeSize windowType { get; set; }

        public Form1()
        {
            InitializeComponent();
            menuStrip1.Visible = false;

            using (var data = new SaveGameContext())
            {
                    var query = (from b in data.Levels select b);
                    foreach (var item in query)
                    {
                        levels = item;
                        data.Levels.Remove(item);
                    }
                    data.SaveChanges();
                    if (levels == null) levels = new Levels(true);
            }
            this.BackgroundImage = Resources.finkiman;
            levels = new Levels(true);
            windowType = WindowTypeSize.big;
            DoubleBuffered = true;
            animationFinish = new Timer();
            animationFinish.Interval = 5;
            animationFinish.Tick += new EventHandler(animationFinish_Tick);          
            levelTimer = new Timer();
            levelTimer.Interval = 1000;
            levelTimer.Tick += new EventHandler(levelTimer_Tick);
            timeRect = new Rectangle(6 * Game.squareDimension + 2 * Figura.paddingX, menuStrip1.Height, 2* Game.squareDimension, Game.squareDimension);
            FontSize = 14;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            initializePoints();
            paused = false;
            pauseMoves = pauseTime = 0;
            mainWindow = true;
            
        }

        /// <summary>
        /// Metoda za povikuvanje na glavnoto meni
        /// </summary>
        public void main_menu()
        {
            btnStart.Visible = true;
            btnExit.Visible = true;
            //levelTimer.Stop();
            btnStart.Text = "R e s u m e";
            mainWindow = true;
            Height = 500;
            Width = 400;
        }
        /// <summary>
        /// Timer za izminato vreme
        /// </summary>
        void levelTimer_Tick(object sender, EventArgs e)
        {
            timePerLevel++;
            Invalidate();
        }

        /// <summary>
        /// Metoda za nova igra
        /// </summary>
        public void newGame()
        {
            dX = dY = 0;
            moving = false;
            timePerLevel = 0;
            movesPerLevel = 0;
            game = new Game(levels.getCurrentLevel());
            initializePoints();
            menuStrip1.Visible = true;
            if (windowType == WindowTypeSize.small)
            {
                Game.squareDimension = 30;
                Figura.gap = 1;
                game.reSize();
                this.Height = 285;
                this.Width = 265;
            }
            else if (windowType == WindowTypeSize.medium)
            {
                Game.squareDimension = 60;
                Figura.gap = 2;
                game.reSize();
                this.Height = 510;
                this.Width = 505;
            }
            else
            {
                Game.squareDimension = 100;
                Figura.gap = 4;
                game.reSize();
                this.Height = 800;
                this.Width = 790;
            }
            Invalidate();
            levelTimer.Start();
        }

        /// <summary>
        /// Inicijalizacija na tocki za iscrtuvanje na stranicnite zidovi
        /// </summary>
        private void initializePoints()
        {
            door = new Door(6 * Game.squareDimension + Figura.paddingX * 2, Figura.paddingY + 2 * Game.squareDimension - Game.squareDimension / 2, Game.squareDimension, Game.squareDimension);
            points = new Point[8];
            points[0] = new Point(6*Game.squareDimension + 2 * Figura.paddingX, menuStrip1.Height);
            points[1] = new Point(6*Game.squareDimension + 2 * Figura.paddingX + 2*Game.squareDimension, menuStrip1.Height);
            points[2] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX + 2*Game.squareDimension, 6 * Game.squareDimension + Figura.paddingY + 3*Game.squareDimension/2);
            points[3] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 6 * Game.squareDimension + Figura.paddingY + menuStrip1.Height);
            points[4] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 3 * Game.squareDimension + Figura.paddingY);
            points[5] = new Point(7 * Game.squareDimension + Figura.paddingX, 3 * Game.squareDimension + Figura.paddingY);
            points[6] = new Point(7 * Game.squareDimension + Figura.paddingX, 2 * Game.squareDimension + Figura.paddingY);
            points[7] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 2 * Game.squareDimension + Figura.paddingY);
            points2 = new Point[4];
            points2[0] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX, 6 * Game.squareDimension + Figura.paddingY+10);
            points2[1] = new Point(6 * Game.squareDimension + 2 * Figura.paddingX + 2 * Game.squareDimension, 6 * Game.squareDimension + Figura.paddingY + 3 * Game.squareDimension / 2);
            points2[2] = new Point(0, 6 * Game.squareDimension + Figura.paddingY + 3 * Game.squareDimension / 2);
            points2[3] = new Point(0, 6 * Game.squareDimension + Figura.paddingY+10);

        }
        /// <summary>
        /// Tajmer za otvaranje na vrata
        /// </summary>
        void animationFinish_Tick(object sender, EventArgs e)
        {

            if (door.opening() || game.drawFinish())
            {
                Invalidate();
            }
            else
            {
                animationFinish.Stop();
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!game.prepareMove(e.X, e.Y))
            {
                return;
            }
            
            dX = e.X;
            dY = e.Y;
            moving = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                int dy, dx;
                dx = e.X - dX;
                dy = (e.Y - dY);
                dX = e.X;
                dY = e.Y;
                if (game.moveCurrent(dx, dy))
                {
                    Invalidate();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                while (game.adjust())
                {
                    Invalidate();
                }
                if (game.endGame())
                {
                    animationFinish.Start();
                    levelTimer.Stop();
                    levels.getCurrentLevel().Finished = true;
                    levels.getCurrentLevel().Time = timePerLevel;
                    levels.getCurrentLevel().Moves = movesPerLevel;
                    using (var soundPlayer = new SoundPlayer(Resources.applause))
                    {
                        soundPlayer.Play();
                    }
                    DialogResult d = MessageBox.Show("Continue to next level?", "Level finished", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        if (levels.CurrentLevel == levels.Count - 1)
                        {
                            int[] bt = new int[levels.Count];
                            int[] bm = new int[levels.Count];
                            for (int i = 0; i < levels.Count; i++)
                            {
                                bt[i] = levels[i].Time;
                                bm[i] = levels[i].Moves;
                            }
                            levels = new Levels(levels.Male);
                            for (int i = 0; i < levels.Count; i++)
                            {
                                levels[i].Time = bt[i];
                                levels[i].Moves = bm[i];
                            }
                        }
                        levels.nextLevel();
                        newGame();
                        animationFinish.Stop();
                    }
                    else
                    {
                        if (levels.CurrentLevel == levels.Count - 1)
                        {
                            int[] bt = new int[levels.Count];
                            int[] bm = new int[levels.Count];
                            for (int i = 0; i < levels.Count; i++)
                            {
                                bt[i] = levels[i].Time;
                                bm[i] = levels[i].Moves;
                            }
                            levels = new Levels(levels.Male);
                            for (int i = 0; i < levels.Count; i++)
                            {
                                levels[i].Time = bt[i];
                                levels[i].Moves = bm[i];
                            }
                        }
                        animationFinish.Stop();
                        levels.nextLevel();
                        main_menu();
                    }
                }
                else
                {
                    game.finishMove();
                    movesPerLevel++;
                   
                }
                moving = false;
               
            }
            dX = dY = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!mainWindow)
            {

                e.Graphics.DrawImage(Resources.grid, new Rectangle(0, this.menuStrip1.Height, 6 * Game.squareDimension + 2 * Figura.paddingX, 6 * Game.squareDimension + menuStrip1.Height));
                game.draw(e.Graphics);
                e.Graphics.FillPolygon(new SolidBrush(Color.SandyBrown), points);
                e.Graphics.FillPolygon(new SolidBrush(Color.BurlyWood), points2);
                door.draw(e.Graphics);
                e.Graphics.DrawRectangle(new Pen(Color.Black), timeRect);
                e.Graphics.DrawString(string.Format("{0:00}:{1:00} moves:{2}\n{3}", timePerLevel / 60, timePerLevel % 60, movesPerLevel, levels.getCurrentLevel().ToString()), new Font("Comic Sans MS", FontSize), new SolidBrush(Color.Black), timeRect);
            }
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.squareDimension = 30;
            initializePoints();
            Figura.gap = 1;
            game.reSize();
            this.Height = 288;
            this.Width = 268;
            windowType = WindowTypeSize.small;
            timeRect = new Rectangle(6 * Game.squareDimension + 2 * Figura.paddingX, menuStrip1.Height, 2 * Game.squareDimension, Game.squareDimension);
            FontSize = 4;
            Invalidate();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.squareDimension = 60;
            initializePoints();
            Figura.gap = 2;
            game.reSize();
            this.Height = 513;
            this.Width = 508;
            windowType = WindowTypeSize.medium;
            timeRect = new Rectangle(6 * Game.squareDimension + 2 * Figura.paddingX, menuStrip1.Height, 2 * Game.squareDimension, Game.squareDimension);
            FontSize = 8;
            Invalidate();
        }

        private void bigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.squareDimension = 100;
            initializePoints();
            Figura.gap = 4;
            game.reSize();
            this.Height = 800;
            this.Width = 790;
            windowType = WindowTypeSize.big;
            timeRect = new Rectangle(6 * Game.squareDimension + 2 * Figura.paddingX, menuStrip1.Height, 2* Game.squareDimension, Game.squareDimension);
            FontSize = 14;
            Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var db = new SaveGameContext())
            {

                db.Levels.Add(levels);
                db.SaveChanges();

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            using (var soundPlayer = new SoundPlayer(Resources.button_16))
            {
                soundPlayer.Play(); 
            }
            btnStart.Visible = false;
            btnExit.Visible = false;
            kopce1.Visible = false;
            mainWindow = false;
            newGame();
            if (paused)
            {
                timePerLevel = pauseTime;
                movesPerLevel = pauseMoves;
                paused = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void meniTujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_menu();
            
        }

            
        private void maleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            levels.Male = true;
        }

        private void femaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            levels.Male = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var soundPlayer = new SoundPlayer(Resources.HeyThere))
            {
                soundPlayer.Play();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game = new Game(levels.OriginalCurrentLevel);
            movesPerLevel = 0;
            timePerLevel = 0;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            pauseTime = timePerLevel;
            pauseMoves = movesPerLevel;
            paused = true;
            main_menu();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helpMenu h = new helpMenu();
            h.Show();
        }

        private void kopce1_Click(object sender, EventArgs e)
        {
            using (var soundPlayer = new SoundPlayer(Resources.button_16))
            {
                soundPlayer.Play();
            }
            helpMenu h = new helpMenu();
            h.Show();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credits c = new Credits();
            c.Show();
           
        }


    }
}
