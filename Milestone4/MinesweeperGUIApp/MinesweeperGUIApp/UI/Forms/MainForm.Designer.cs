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
            pnlMain = new Panel();
            lblBombs = new Label();
            lblBombsValue = new Label();
            lblRewards = new Label();
            lblRewardsValue = new Label();
            btnRestart = new Button();
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
            lblBombs.Location = new Point(516, 22);
            lblBombs.Name = "lblBombs";
            lblBombs.Size = new Size(134, 20);
            lblBombs.TabIndex = 1;
            lblBombs.Text = "Number of Bombs:";
            // 
            // lblBombsValue
            // 
            lblBombsValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBombsValue.AutoSize = true;
            lblBombsValue.Font = new Font("Segoe UI", 16F);
            lblBombsValue.Location = new Point(569, 48);
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
            lblRewards.Location = new Point(516, 94);
            lblRewards.Name = "lblRewards";
            lblRewards.Size = new Size(144, 20);
            lblRewards.TabIndex = 3;
            lblRewards.Text = "Number of Rewards:";
            // 
            // lblRewardsValue
            // 
            lblRewardsValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRewardsValue.AutoSize = true;
            lblRewardsValue.Font = new Font("Segoe UI", 16F);
            lblRewardsValue.Location = new Point(569, 127);
            lblRewardsValue.Name = "lblRewardsValue";
            lblRewardsValue.Size = new Size(37, 30);
            lblRewardsValue.TabIndex = 4;
            lblRewardsValue.Text = "00";
            // 
            // btnRestart
            // 
            btnRestart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestart.Location = new Point(549, 171);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(75, 23);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 521);
            Controls.Add(btnRestart);
            Controls.Add(lblRewardsValue);
            Controls.Add(lblRewards);
            Controls.Add(lblBombsValue);
            Controls.Add(lblBombs);
            Controls.Add(pnlMain);
            Name = "MainForm";
            Text = "Mine Sweeper";
            Load += MainForm_Load;
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
    }
}