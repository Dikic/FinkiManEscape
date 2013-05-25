namespace FinkiManEscape
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meniTujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.femaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kopce1 = new FinkiManEscape.Kopce();
            this.btnExit = new FinkiManEscape.Kopce();
            this.btnStart = new FinkiManEscape.Kopce();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.creditsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(392, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meniTujToolStripMenuItem,
            this.windowSizeToolStripMenuItem,
            this.genderToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // meniTujToolStripMenuItem
            // 
            this.meniTujToolStripMenuItem.Name = "meniTujToolStripMenuItem";
            this.meniTujToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.meniTujToolStripMenuItem.Text = "Main Menu";
            this.meniTujToolStripMenuItem.Click += new System.EventHandler(this.meniTujToolStripMenuItem_Click);
            // 
            // windowSizeToolStripMenuItem
            // 
            this.windowSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.bigToolStripMenuItem});
            this.windowSizeToolStripMenuItem.Name = "windowSizeToolStripMenuItem";
            this.windowSizeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.windowSizeToolStripMenuItem.Text = "Window Size";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.smallToolStripMenuItem.Text = "Small";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // bigToolStripMenuItem
            // 
            this.bigToolStripMenuItem.Name = "bigToolStripMenuItem";
            this.bigToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.bigToolStripMenuItem.Text = "Big";
            this.bigToolStripMenuItem.Click += new System.EventHandler(this.bigToolStripMenuItem_Click);
            // 
            // genderToolStripMenuItem
            // 
            this.genderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maleToolStripMenuItem,
            this.femaleToolStripMenuItem});
            this.genderToolStripMenuItem.Name = "genderToolStripMenuItem";
            this.genderToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.genderToolStripMenuItem.Text = "Gender";
            // 
            // maleToolStripMenuItem
            // 
            this.maleToolStripMenuItem.Name = "maleToolStripMenuItem";
            this.maleToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.maleToolStripMenuItem.Text = "Male";
            this.maleToolStripMenuItem.Click += new System.EventHandler(this.maleToolStripMenuItem_Click);
            // 
            // femaleToolStripMenuItem
            // 
            this.femaleToolStripMenuItem.Name = "femaleToolStripMenuItem";
            this.femaleToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.femaleToolStripMenuItem.Text = "Female";
            this.femaleToolStripMenuItem.Click += new System.EventHandler(this.femaleToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.helpToolStripMenuItem.Text = "Restart";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // kopce1
            // 
            this.kopce1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kopce1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kopce1.ForeColor = System.Drawing.Color.Gainsboro;
            this.kopce1.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kopce1.GradientTop = System.Drawing.Color.DarkOrange;
            this.kopce1.Location = new System.Drawing.Point(134, 275);
            this.kopce1.Name = "kopce1";
            this.kopce1.Size = new System.Drawing.Size(126, 57);
            this.kopce1.TabIndex = 3;
            this.kopce1.Text = "H e l p";
            this.kopce1.UseVisualStyleBackColor = true;
            this.kopce1.Click += new System.EventHandler(this.kopce1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.GradientTop = System.Drawing.Color.DarkOrange;
            this.btnExit.Location = new System.Drawing.Point(134, 354);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(126, 57);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E x i t";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStart.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStart.GradientTop = System.Drawing.Color.DarkOrange;
            this.btnStart.Location = new System.Drawing.Point(134, 196);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(126, 57);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "S t a r t";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(392, 466);
            this.Controls.Add(this.kopce1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinkiMan Escape";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meniTujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bigToolStripMenuItem;
        private Kopce btnStart;
        private Kopce btnExit;
        private System.Windows.Forms.ToolStripMenuItem genderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem femaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private Kopce kopce1;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
    }
}

