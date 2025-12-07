namespace MinesweeperGUIApp.UI.Forms
{
    partial class SetupForm
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
            trbSize = new TrackBar();
            trbDifficulty = new TrackBar();
            lblSize = new Label();
            lblTitle = new Label();
            lblDifficulty = new Label();
            btnAccept = new Button();
            lblSizeValue = new Label();
            lblDifficultyValue = new Label();
            ((System.ComponentModel.ISupportInitialize)trbSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbDifficulty).BeginInit();
            SuspendLayout();
            // 
            // trbSize
            // 
            trbSize.LargeChange = 2;
            trbSize.Location = new Point(12, 60);
            trbSize.Minimum = 1;
            trbSize.Name = "trbSize";
            trbSize.Size = new Size(241, 45);
            trbSize.TabIndex = 0;
            trbSize.Value = 1;
            trbSize.Scroll += TrbSizeScrollEH;
            // 
            // trbDifficulty
            // 
            trbDifficulty.LargeChange = 1;
            trbDifficulty.Location = new Point(10, 122);
            trbDifficulty.Maximum = 3;
            trbDifficulty.Minimum = 1;
            trbDifficulty.Name = "trbDifficulty";
            trbDifficulty.Size = new Size(243, 45);
            trbDifficulty.TabIndex = 1;
            trbDifficulty.Value = 1;
            trbDifficulty.Scroll += TrbDifficultyScrollEH;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(12, 42);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(30, 15);
            lblSize.TabIndex = 2;
            lblSize.Text = "Size:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(10, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(121, 17);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Minsweeper Setup";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(10, 104);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(55, 15);
            lblDifficulty.TabIndex = 4;
            lblDifficulty.Text = "Difficulty";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(91, 167);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 23);
            btnAccept.TabIndex = 5;
            btnAccept.Text = "Play";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += BtnAcceptClickEH;
            // 
            // lblSizeValue
            // 
            lblSizeValue.AutoSize = true;
            lblSizeValue.Location = new Point(48, 42);
            lblSizeValue.Name = "lblSizeValue";
            lblSizeValue.Size = new Size(0, 15);
            lblSizeValue.TabIndex = 6;
            // 
            // lblDifficultyValue
            // 
            lblDifficultyValue.AutoSize = true;
            lblDifficultyValue.Location = new Point(71, 104);
            lblDifficultyValue.Name = "lblDifficultyValue";
            lblDifficultyValue.Size = new Size(0, 15);
            lblDifficultyValue.TabIndex = 7;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 201);
            Controls.Add(lblDifficultyValue);
            Controls.Add(lblSizeValue);
            Controls.Add(btnAccept);
            Controls.Add(lblDifficulty);
            Controls.Add(lblTitle);
            Controls.Add(lblSize);
            Controls.Add(trbDifficulty);
            Controls.Add(trbSize);
            Name = "SetupForm";
            Text = "Setup";
            Load += SetupFormLoadEH;
            ((System.ComponentModel.ISupportInitialize)trbSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbDifficulty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trbSize;
        private TrackBar trbDifficulty;
        private Label lblSize;
        private Label lblTitle;
        private Label lblDifficulty;
        private Button btnAccept;
        private Label lblSizeValue;
        private Label lblDifficultyValue;
    }
}