namespace MinesweeperGUIApp.UI.Forms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            pnlMain = new Panel();
            lblBombs = new Label();
            lblBombsValue = new Label();
            lblRewards = new Label();
            lblRewardsValue = new Label();
            btnRestart = new Button();
            btnPause = new Button();
            lblTime = new Label();
            lblTimeValue = new Label();
            tmrElapsedTime = new System.Windows.Forms.Timer(components);
            mnuMainMenu = new MenuStrip();
            tsmFile = new ToolStripMenuItem();
            tsmFileSave = new ToolStripMenuItem();
            tsmFileLoad = new ToolStripMenuItem();
            tsmFileExit = new ToolStripMenuItem();
            tsmMusic = new ToolStripMenuItem();
            tsmMusicMute = new ToolStripMenuItem();
            tsmMusicUp = new ToolStripMenuItem();
            tsmMusicUp10 = new ToolStripMenuItem();
            tsmMusicUp20 = new ToolStripMenuItem();
            tsmMusicUp50 = new ToolStripMenuItem();
            tsmMusicUpMax = new ToolStripMenuItem();
            tsmMusicDown = new ToolStripMenuItem();
            tsmMusicDown10 = new ToolStripMenuItem();
            tsmMusicDown20 = new ToolStripMenuItem();
            tsmMusicDown50 = new ToolStripMenuItem();
            tsmMusicDownMin = new ToolStripMenuItem();
            mnuMainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMain.Location = new Point(6, 29);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(500, 500);
            pnlMain.TabIndex = 0;
            // 
            // lblBombs
            // 
            lblBombs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBombs.AutoSize = true;
            lblBombs.Font = new Font("Segoe UI", 11F);
            lblBombs.Location = new Point(519, 34);
            lblBombs.Name = "lblBombs";
            lblBombs.Size = new Size(58, 20);
            lblBombs.TabIndex = 1;
            lblBombs.Text = "Bombs:";
            // 
            // lblBombsValue
            // 
            lblBombsValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBombsValue.AutoSize = true;
            lblBombsValue.Font = new Font("Segoe UI", 16F);
            lblBombsValue.Location = new Point(584, 28);
            lblBombsValue.Name = "lblBombsValue";
            lblBombsValue.Size = new Size(37, 30);
            lblBombsValue.TabIndex = 2;
            lblBombsValue.Text = "00";
            // 
            // lblRewards
            // 
            lblRewards.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRewards.AutoSize = true;
            lblRewards.Font = new Font("Segoe UI", 11F);
            lblRewards.Location = new Point(519, 64);
            lblRewards.Name = "lblRewards";
            lblRewards.Size = new Size(68, 20);
            lblRewards.TabIndex = 3;
            lblRewards.Text = "Rewards:";
            // 
            // lblRewardsValue
            // 
            lblRewardsValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRewardsValue.AutoSize = true;
            lblRewardsValue.Font = new Font("Segoe UI", 16F);
            lblRewardsValue.Location = new Point(584, 58);
            lblRewardsValue.Name = "lblRewardsValue";
            lblRewardsValue.Size = new Size(37, 30);
            lblRewardsValue.TabIndex = 4;
            lblRewardsValue.Text = "00";
            // 
            // btnRestart
            // 
            btnRestart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestart.Location = new Point(552, 151);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(75, 23);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += BtnRestartClickEH;
            // 
            // btnPause
            // 
            btnPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPause.Location = new Point(552, 500);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 6;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += BtnPauseClickEH;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(521, 96);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(45, 20);
            lblTime.TabIndex = 7;
            lblTime.Text = "Time:";
            // 
            // lblTimeValue
            // 
            lblTimeValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimeValue.AutoSize = true;
            lblTimeValue.Font = new Font("Segoe UI", 16F);
            lblTimeValue.Location = new Point(568, 90);
            lblTimeValue.Name = "lblTimeValue";
            lblTimeValue.Size = new Size(83, 30);
            lblTimeValue.TabIndex = 8;
            lblTimeValue.Text = "0:00:00";
            // 
            // tmrElapsedTime
            // 
            tmrElapsedTime.Tag = 0;
            tmrElapsedTime.Tick += TmrElapsedTimeTickEH;
            // 
            // mnuMainMenu
            // 
            mnuMainMenu.Items.AddRange(new ToolStripItem[] { tsmFile, tsmMusic });
            mnuMainMenu.Location = new Point(0, 0);
            mnuMainMenu.Name = "mnuMainMenu";
            mnuMainMenu.Size = new Size(664, 24);
            mnuMainMenu.TabIndex = 9;
            mnuMainMenu.Text = "MainMenu";
            // 
            // tsmFile
            // 
            tsmFile.DropDownItems.AddRange(new ToolStripItem[] { tsmFileSave, tsmFileLoad, tsmFileExit });
            tsmFile.Name = "tsmFile";
            tsmFile.Size = new Size(37, 20);
            tsmFile.Text = "File";
            // 
            // tsmFileSave
            // 
            tsmFileSave.Name = "tsmFileSave";
            tsmFileSave.Size = new Size(180, 22);
            tsmFileSave.Text = "Save Game";
            tsmFileSave.Click += TsmFileSaveClickEH;
            // 
            // tsmFileLoad
            // 
            tsmFileLoad.Name = "tsmFileLoad";
            tsmFileLoad.Size = new Size(180, 22);
            tsmFileLoad.Text = "Load Game";
            tsmFileLoad.Click += TsmFileLoadClickEH;
            // 
            // tsmFileExit
            // 
            tsmFileExit.Name = "tsmFileExit";
            tsmFileExit.Size = new Size(180, 22);
            tsmFileExit.Text = "Exit";
            tsmFileExit.Click += TsmFileExitClickEH;
            // 
            // tsmMusic
            // 
            tsmMusic.DropDownItems.AddRange(new ToolStripItem[] { tsmMusicMute, tsmMusicUp, tsmMusicDown });
            tsmMusic.Name = "tsmMusic";
            tsmMusic.Size = new Size(51, 20);
            tsmMusic.Text = "Music";
            // 
            // tsmMusicMute
            // 
            tsmMusicMute.Name = "tsmMusicMute";
            tsmMusicMute.Size = new Size(180, 22);
            tsmMusicMute.Text = "Pause(Mute)";
            tsmMusicMute.Click += TsmMusicMuteClickEH;
            // 
            // tsmMusicUp
            // 
            tsmMusicUp.DropDownItems.AddRange(new ToolStripItem[] { tsmMusicUp10, tsmMusicUp20, tsmMusicUp50, tsmMusicUpMax });
            tsmMusicUp.Name = "tsmMusicUp";
            tsmMusicUp.Size = new Size(180, 22);
            tsmMusicUp.Text = "Up";
            // 
            // tsmMusicUp10
            // 
            tsmMusicUp10.Name = "tsmMusicUp10";
            tsmMusicUp10.Size = new Size(96, 22);
            tsmMusicUp10.Text = "10";
            tsmMusicUp10.Click += TsmMusicUp10ClickEH;
            // 
            // tsmMusicUp20
            // 
            tsmMusicUp20.Name = "tsmMusicUp20";
            tsmMusicUp20.Size = new Size(96, 22);
            tsmMusicUp20.Text = "20";
            tsmMusicUp20.Click += TsmMusicUp20ClickEH;
            // 
            // tsmMusicUp50
            // 
            tsmMusicUp50.Name = "tsmMusicUp50";
            tsmMusicUp50.Size = new Size(96, 22);
            tsmMusicUp50.Text = "50";
            tsmMusicUp50.Click += TsmMusicUp50ClickEH;
            // 
            // tsmMusicUpMax
            // 
            tsmMusicUpMax.Name = "tsmMusicUpMax";
            tsmMusicUpMax.Size = new Size(96, 22);
            tsmMusicUpMax.Text = "Max";
            tsmMusicUpMax.Click += TsmMusicUpMaxClickEH;
            // 
            // tsmMusicDown
            // 
            tsmMusicDown.DropDownItems.AddRange(new ToolStripItem[] { tsmMusicDown10, tsmMusicDown20, tsmMusicDown50, tsmMusicDownMin });
            tsmMusicDown.Name = "tsmMusicDown";
            tsmMusicDown.Size = new Size(180, 22);
            tsmMusicDown.Text = "Down";
            // 
            // tsmMusicDown10
            // 
            tsmMusicDown10.Name = "tsmMusicDown10";
            tsmMusicDown10.Size = new Size(95, 22);
            tsmMusicDown10.Text = "10";
            tsmMusicDown10.Click += TsmMusicDown10ClickEH;
            // 
            // tsmMusicDown20
            // 
            tsmMusicDown20.Name = "tsmMusicDown20";
            tsmMusicDown20.Size = new Size(95, 22);
            tsmMusicDown20.Text = "20";
            tsmMusicDown20.Click += TsmMusicDown20ClickEH;
            // 
            // tsmMusicDown50
            // 
            tsmMusicDown50.Name = "tsmMusicDown50";
            tsmMusicDown50.Size = new Size(95, 22);
            tsmMusicDown50.Text = "50";
            tsmMusicDown50.Click += TsmMusicDown50ClickEH;
            // 
            // tsmMusicDownMin
            // 
            tsmMusicDownMin.Name = "tsmMusicDownMin";
            tsmMusicDownMin.Size = new Size(95, 22);
            tsmMusicDownMin.Text = "Min";
            tsmMusicDownMin.Click += TsmMusicDownMinClickEH;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 535);
            Controls.Add(lblTimeValue);
            Controls.Add(lblTime);
            Controls.Add(btnPause);
            Controls.Add(btnRestart);
            Controls.Add(lblRewardsValue);
            Controls.Add(lblRewards);
            Controls.Add(lblBombsValue);
            Controls.Add(lblBombs);
            Controls.Add(pnlMain);
            Controls.Add(mnuMainMenu);
            MainMenuStrip = mnuMainMenu;
            Name = "MainForm";
            Text = "Mine Sweeper";
            FormClosing += MainFormClosingEH;
            mnuMainMenu.ResumeLayout(false);
            mnuMainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMain;
        private Label lblBombs;
        private Label lblBombsValue;
        private Label lblRewards;
        private Label lblRewardsValue;
        private Button btnRestart;
        private Button btnPause;
        private Label lblTime;
        private Label lblTimeValue;
        private System.Windows.Forms.Timer tmrElapsedTime;
        private MenuStrip mnuMainMenu;
        private ToolStripMenuItem tsmFile;
        private ToolStripMenuItem tsmFileSave;
        private ToolStripMenuItem tsmFileLoad;
        private ToolStripMenuItem tsmFileExit;
        private ToolStripMenuItem tsmMusic;
        private ToolStripMenuItem tsmMusicMute;
        private ToolStripMenuItem tsmMusicUp;
        private ToolStripMenuItem tsmMusicDown;
        private ToolStripMenuItem tsmMusicUp10;
        private ToolStripMenuItem tsmMusicUp20;
        private ToolStripMenuItem tsmMusicUp50;
        private ToolStripMenuItem tsmMusicUpMax;
        private ToolStripMenuItem tsmMusicDown10;
        private ToolStripMenuItem tsmMusicDown20;
        private ToolStripMenuItem tsmMusicDown50;
        private ToolStripMenuItem tsmMusicDownMin;
    }
}