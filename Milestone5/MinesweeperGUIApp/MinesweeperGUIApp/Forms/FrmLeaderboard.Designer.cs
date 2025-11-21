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
            SuspendLayout();
            // 
            // lblHighScores
            // 
            lblHighScores.Font = new Font("Segoe UI", 15.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblHighScores.Location = new Point(0, 36);
            lblHighScores.Name = "lblHighScores";
            lblHighScores.Size = new Size(607, 28);
            lblHighScores.TabIndex = 0;
            lblHighScores.Text = "      Top Times                                                                                                 ";
            // 
            // lblHighScoresValue
            // 
            lblHighScoresValue.AutoSize = true;
            lblHighScoresValue.Location = new Point(51, 79);
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
            cmbBoardSize.Location = new Point(500, 12);
            cmbBoardSize.Name = "cmbBoardSize";
            cmbBoardSize.Size = new Size(94, 23);
            cmbBoardSize.TabIndex = 2;
            // 
            // lblBoardSize
            // 
            lblBoardSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(399, 16);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(98, 15);
            lblBoardSize.TabIndex = 3;
            lblBoardSize.Text = "Select Board Size:";
            // 
            // FrmLeaderboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 699);
            Controls.Add(lblBoardSize);
            Controls.Add(cmbBoardSize);
            Controls.Add(lblHighScoresValue);
            Controls.Add(lblHighScores);
            Name = "FrmLeaderboard";
            Text = "Leaderboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHighScores;
        private Label lblHighScoresValue;
        private ComboBox cmbBoardSize;
        private Label lblBoardSize;
    }
}