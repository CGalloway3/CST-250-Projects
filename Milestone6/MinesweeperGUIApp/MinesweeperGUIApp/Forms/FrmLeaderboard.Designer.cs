namespace MinesweeperGUIApp.Forms
{
    partial class FrmLeaderboard
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
            lblHighScores = new Label();
            lblHighScoresValue = new Label();
            cmbBoardSize = new ComboBox();
            lblBoardSize = new Label();
            lblYourScore = new Label();
            lblYourScoreValue = new Label();
            dgvHighScores = new DataGridView();
            mnuMainLeaderboard = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileSave = new ToolStripMenuItem();
            mnuFileLoad = new ToolStripMenuItem();
            mnuFileExit = new ToolStripMenuItem();
            mnuSort = new ToolStripMenuItem();
            mnuSortByName = new ToolStripMenuItem();
            mnuSortByScore = new ToolStripMenuItem();
            mnuSortByDate = new ToolStripMenuItem();
            mnuSortByBoardSize = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).BeginInit();
            mnuMainLeaderboard.SuspendLayout();
            SuspendLayout();
            // 
            // lblHighScores
            // 
            lblHighScores.Font = new Font("Segoe UI", 15.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblHighScores.Location = new Point(1, 75);
            lblHighScores.Name = "lblHighScores";
            lblHighScores.Size = new Size(607, 28);
            lblHighScores.TabIndex = 0;
            lblHighScores.Text = "      Top Scores                                                                                            ";
            // 
            // lblHighScoresValue
            // 
            lblHighScoresValue.AutoSize = true;
            lblHighScoresValue.Location = new Point(51, 154);
            lblHighScoresValue.Name = "lblHighScoresValue";
            lblHighScoresValue.Size = new Size(64, 15);
            lblHighScoresValue.TabIndex = 1;
            lblHighScoresValue.Text = "Best Times";
            // 
            // cmbBoardSize
            // 
            cmbBoardSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbBoardSize.FormattingEnabled = true;
            cmbBoardSize.Items.AddRange(new object[] { "4 x 4", "8 x 8", "12 x 12", "16 x 16", "20 x 20", "24 x 24", "28 x 28", "32 x 32", "36 x 36", "40 x 40" });
            cmbBoardSize.Location = new Point(330, 40);
            cmbBoardSize.Name = "cmbBoardSize";
            cmbBoardSize.Size = new Size(94, 23);
            cmbBoardSize.TabIndex = 2;
            // 
            // lblBoardSize
            // 
            lblBoardSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(229, 44);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(98, 15);
            lblBoardSize.TabIndex = 3;
            lblBoardSize.Text = "Select Board Size:";
            // 
            // lblYourScore
            // 
            lblYourScore.AutoSize = true;
            lblYourScore.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYourScore.Location = new Point(25, 36);
            lblYourScore.Name = "lblYourScore";
            lblYourScore.Size = new Size(86, 20);
            lblYourScore.TabIndex = 4;
            lblYourScore.Text = "Your Score: ";
            // 
            // lblYourScoreValue
            // 
            lblYourScoreValue.AutoSize = true;
            lblYourScoreValue.Location = new Point(113, 40);
            lblYourScoreValue.Name = "lblYourScoreValue";
            lblYourScoreValue.Size = new Size(31, 15);
            lblYourScoreValue.TabIndex = 5;
            lblYourScoreValue.Text = "3000";
            // 
            // dgvHighScores
            // 
            dgvHighScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHighScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHighScores.Location = new Point(12, 116);
            dgvHighScores.Name = "dgvHighScores";
            dgvHighScores.Size = new Size(443, 370);
            dgvHighScores.TabIndex = 7;
            dgvHighScores.ColumnHeaderMouseClick += DgvHighScoresColumnHeaderMouseClickEH;
            // 
            // mnuMainLeaderboard
            // 
            mnuMainLeaderboard.Items.AddRange(new ToolStripItem[] { mnuFile, mnuSort });
            mnuMainLeaderboard.Location = new Point(0, 0);
            mnuMainLeaderboard.Name = "mnuMainLeaderboard";
            mnuMainLeaderboard.Size = new Size(467, 24);
            mnuMainLeaderboard.TabIndex = 8;
            mnuMainLeaderboard.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileSave, mnuFileLoad, mnuFileExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(37, 20);
            mnuFile.Text = "File";
            // 
            // mnuFileSave
            // 
            mnuFileSave.Name = "mnuFileSave";
            mnuFileSave.Size = new Size(100, 22);
            mnuFileSave.Text = "Save";
            mnuFileSave.Click += MnuFileSaveClickEH;
            // 
            // mnuFileLoad
            // 
            mnuFileLoad.Name = "mnuFileLoad";
            mnuFileLoad.Size = new Size(100, 22);
            mnuFileLoad.Text = "Load";
            mnuFileLoad.Click += MnuFileLoadClickEH;
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.Size = new Size(100, 22);
            mnuFileExit.Text = "Exit";
            mnuFileExit.Click += MnuFileExitClickEH;
            // 
            // mnuSort
            // 
            mnuSort.DropDownItems.AddRange(new ToolStripItem[] { mnuSortByName, mnuSortByScore, mnuSortByDate, mnuSortByBoardSize });
            mnuSort.Name = "mnuSort";
            mnuSort.Size = new Size(40, 20);
            mnuSort.Text = "Sort";
            // 
            // mnuSortByName
            // 
            mnuSortByName.Name = "mnuSortByName";
            mnuSortByName.Size = new Size(144, 22);
            mnuSortByName.Text = "By Name";
            mnuSortByName.Click += MnuSortByNameClickEH;
            // 
            // mnuSortByScore
            // 
            mnuSortByScore.Name = "mnuSortByScore";
            mnuSortByScore.Size = new Size(144, 22);
            mnuSortByScore.Text = "By Score";
            mnuSortByScore.Click += MnuSortByScoreClickEH;
            // 
            // mnuSortByDate
            // 
            mnuSortByDate.Name = "mnuSortByDate";
            mnuSortByDate.Size = new Size(144, 22);
            mnuSortByDate.Text = "By Date";
            mnuSortByDate.Click += MnuSortByDateClickEH;
            // 
            // mnuSortByBoardSize
            // 
            mnuSortByBoardSize.Name = "mnuSortByBoardSize";
            mnuSortByBoardSize.Size = new Size(144, 22);
            mnuSortByBoardSize.Text = "By Board Size";
            // 
            // FrmLeaderboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 493);
            Controls.Add(dgvHighScores);
            Controls.Add(lblYourScoreValue);
            Controls.Add(lblYourScore);
            Controls.Add(lblBoardSize);
            Controls.Add(cmbBoardSize);
            Controls.Add(lblHighScoresValue);
            Controls.Add(lblHighScores);
            Controls.Add(mnuMainLeaderboard);
            Name = "FrmLeaderboard";
            Text = "Leaderboard";
            FormClosing += FrmLeaderboardFormClosingEH;
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).EndInit();
            mnuMainLeaderboard.ResumeLayout(false);
            mnuMainLeaderboard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHighScores;
        private Label lblHighScoresValue;
        private ComboBox cmbBoardSize;
        private Label lblBoardSize;
        private Label lblYourScore;
        private Label lblYourScoreValue;
        private DataGridView dgvHighScores;
        private MenuStrip mnuMainLeaderboard;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileSave;
        private ToolStripMenuItem mnuFileLoad;
        private ToolStripMenuItem mnuFileExit;
        private ToolStripMenuItem mnuSort;
        private ToolStripMenuItem mnuSortByName;
        private ToolStripMenuItem mnuSortByScore;
        private ToolStripMenuItem mnuSortByDate;
        private ToolStripMenuItem mnuSortByBoardSize;
    }
}