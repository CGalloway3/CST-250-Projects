
namespace WhackAMoleGUI.PresentationLayer
{
    partial class FrmStopwatch
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnPause = new Button();
            btnReset = new Button();
            lblTimeElapsed = new Label();
            tmrStopwatch = new System.Windows.Forms.Timer(components);
            btnTarget = new Button();
            pnlGameArea = new Panel();
            lblHint = new Label();
            lblWave = new Label();
            lblPlayerName = new Label();
            lblPlayerNameValue = new Label();
            lblScore = new Label();
            lblScoreValue = new Label();
            lblAccuracy = new Label();
            lblAccuracyValue = new Label();
            btnHighScores = new Button();
            btnExit = new Button();
            pnlGameArea.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.Location = new Point(12, 528);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Begin";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStartClickEH;
            // 
            // btnPause
            // 
            btnPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPause.Location = new Point(93, 528);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 1;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += BtnPauseClickEH;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.Location = new Point(643, 421);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 45);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset Difficulty";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnResetClickEH;
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Location = new Point(14, 7);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(49, 15);
            lblTimeElapsed.TabIndex = 3;
            lblTimeElapsed.Text = "00:00:00";
            lblTimeElapsed.TextAlign = ContentAlignment.TopCenter;
            // 
            // tmrStopwatch
            // 
            tmrStopwatch.Enabled = true;
            tmrStopwatch.Interval = 1000;
            tmrStopwatch.Tick += TmrStopwatchTickEH;
            // 
            // btnTarget
            // 
            btnTarget.BackColor = Color.Transparent;
            btnTarget.BackgroundImage = Resources.DeerTarget;
            btnTarget.BackgroundImageLayout = ImageLayout.Stretch;
            btnTarget.FlatAppearance.BorderSize = 0;
            btnTarget.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnTarget.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnTarget.FlatStyle = FlatStyle.Flat;
            btnTarget.Location = new Point(334, 159);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(75, 75);
            btnTarget.TabIndex = 4;
            btnTarget.UseVisualStyleBackColor = false;
            btnTarget.Visible = false;
            btnTarget.Click += BtnTargetClickEH;
            // 
            // pnlGameArea
            // 
            pnlGameArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGameArea.BackgroundImage = Resources.Wave1Background;
            pnlGameArea.BackgroundImageLayout = ImageLayout.Stretch;
            pnlGameArea.Controls.Add(lblHint);
            pnlGameArea.Controls.Add(lblWave);
            pnlGameArea.Controls.Add(btnTarget);
            pnlGameArea.Cursor = Cursors.Cross;
            pnlGameArea.Location = new Point(0, 27);
            pnlGameArea.Name = "pnlGameArea";
            pnlGameArea.Size = new Size(627, 490);
            pnlGameArea.TabIndex = 5;
            pnlGameArea.Click += PnlGameAreaClickEH;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.BackColor = Color.Transparent;
            lblHint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHint.ForeColor = Color.Red;
            lblHint.Location = new Point(272, 266);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(90, 21);
            lblHint.TabIndex = 15;
            lblHint.Text = "Press Begin";
            // 
            // lblWave
            // 
            lblWave.AutoSize = true;
            lblWave.BackColor = Color.Transparent;
            lblWave.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWave.ForeColor = Color.Red;
            lblWave.Location = new Point(221, 210);
            lblWave.Name = "lblWave";
            lblWave.Size = new Size(188, 56);
            lblWave.TabIndex = 14;
            lblWave.Text = "Wave 1";
            // 
            // lblPlayerName
            // 
            lblPlayerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPlayerName.AutoSize = true;
            lblPlayerName.Location = new Point(634, 29);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(77, 15);
            lblPlayerName.TabIndex = 6;
            lblPlayerName.Text = "Player Name:";
            // 
            // lblPlayerNameValue
            // 
            lblPlayerNameValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPlayerNameValue.AutoSize = true;
            lblPlayerNameValue.Location = new Point(643, 46);
            lblPlayerNameValue.Name = "lblPlayerNameValue";
            lblPlayerNameValue.Size = new Size(45, 15);
            lblPlayerNameValue.TabIndex = 7;
            lblPlayerNameValue.Text = "Player1";
            // 
            // lblScore
            // 
            lblScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScore.AutoSize = true;
            lblScore.Location = new Point(641, 72);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(39, 15);
            lblScore.TabIndex = 8;
            lblScore.Text = "Score:";
            // 
            // lblScoreValue
            // 
            lblScoreValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScoreValue.AutoSize = true;
            lblScoreValue.Location = new Point(650, 89);
            lblScoreValue.Name = "lblScoreValue";
            lblScoreValue.Size = new Size(31, 15);
            lblScoreValue.TabIndex = 9;
            lblScoreValue.Text = "0000";
            // 
            // lblAccuracy
            // 
            lblAccuracy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAccuracy.AutoSize = true;
            lblAccuracy.Location = new Point(641, 115);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(59, 15);
            lblAccuracy.TabIndex = 10;
            lblAccuracy.Text = "Accuracy:";
            // 
            // lblAccuracyValue
            // 
            lblAccuracyValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAccuracyValue.AutoSize = true;
            lblAccuracyValue.Location = new Point(650, 134);
            lblAccuracyValue.Name = "lblAccuracyValue";
            lblAccuracyValue.Size = new Size(35, 15);
            lblAccuracyValue.TabIndex = 11;
            lblAccuracyValue.Text = "100%";
            // 
            // btnHighScores
            // 
            btnHighScores.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHighScores.Location = new Point(643, 472);
            btnHighScores.Name = "btnHighScores";
            btnHighScores.Size = new Size(75, 45);
            btnHighScores.TabIndex = 12;
            btnHighScores.Text = "   View    Scores";
            btnHighScores.UseVisualStyleBackColor = true;
            btnHighScores.Click += BtnHighScoresClickEH;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExit.Location = new Point(643, 528);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 13;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExitClickEH;
            // 
            // FrmStopwatch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 558);
            Controls.Add(btnExit);
            Controls.Add(btnHighScores);
            Controls.Add(lblAccuracyValue);
            Controls.Add(lblAccuracy);
            Controls.Add(lblScoreValue);
            Controls.Add(lblScore);
            Controls.Add(lblPlayerNameValue);
            Controls.Add(lblPlayerName);
            Controls.Add(pnlGameArea);
            Controls.Add(lblTimeElapsed);
            Controls.Add(btnReset);
            Controls.Add(btnPause);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MinimumSize = new Size(275, 185);
            Name = "FrmStopwatch";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Stopwatch";
            pnlGameArea.ResumeLayout(false);
            pnlGameArea.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button btnStart;
        private Button btnPause;
        private Button btnReset;
        private Label lblTimeElapsed;
        private System.Windows.Forms.Timer tmrStopwatch;
        private Button btnTarget;
        private Panel pnlGameArea;
        private Label lblPlayerName;
        private Label lblPlayerNameValue;
        private Label lblScore;
        private Label lblScoreValue;
        private Label lblAccuracy;
        private Label lblAccuracyValue;
        private Button btnHighScores;
        private Button btnExit;
        private Label lblWave;
        private Label lblHint;
    }
}
