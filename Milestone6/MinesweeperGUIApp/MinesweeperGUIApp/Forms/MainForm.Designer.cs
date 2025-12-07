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
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMain.Location = new Point(12, 12);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(500, 500);
            pnlMain.TabIndex = 0;
            // 
            // lblBombs
            // 
            lblBombs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBombs.AutoSize = true;
            lblBombs.Font = new Font("Segoe UI", 11F);
            lblBombs.Location = new Point(516, 20);
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
            lblBombsValue.Location = new Point(581, 14);
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
            lblRewards.Location = new Point(516, 50);
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
            lblRewardsValue.Location = new Point(581, 44);
            lblRewardsValue.Name = "lblRewardsValue";
            lblRewardsValue.Size = new Size(37, 30);
            lblRewardsValue.TabIndex = 4;
            lblRewardsValue.Text = "00";
            // 
            // btnRestart
            // 
            btnRestart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestart.Location = new Point(549, 159);
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
            btnPause.Location = new Point(549, 486);
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
            lblTime.Location = new Point(518, 82);
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
            lblTimeValue.Location = new Point(565, 76);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 521);
            Controls.Add(lblTimeValue);
            Controls.Add(lblTime);
            Controls.Add(btnPause);
            Controls.Add(btnRestart);
            Controls.Add(lblRewardsValue);
            Controls.Add(lblRewards);
            Controls.Add(lblBombsValue);
            Controls.Add(lblBombs);
            Controls.Add(pnlMain);
            Name = "MainForm";
            Text = "Mine Sweeper";
            FormClosing += MainFormClosingEH;
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
    }
}