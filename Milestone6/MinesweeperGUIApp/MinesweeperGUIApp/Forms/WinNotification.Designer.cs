namespace MinesweeperGUIApp.Forms
{
    partial class FrmWinNotification
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
            txtName = new TextBox();
            lblHeader = new Label();
            lblScore = new Label();
            btnOK = new Button();
            lblScoreValue = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(25, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(202, 23);
            txtName.TabIndex = 0;
            txtName.KeyDown += TxtNameKeyDownEH;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(25, 17);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(194, 15);
            lblHeader.TabIndex = 1;
            lblHeader.Text = " Congratulations!  Enter your name.";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(23, 67);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(39, 15);
            lblScore.TabIndex = 2;
            lblScore.Text = "Score:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(92, 95);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOKClickEH;
            // 
            // lblScoreValue
            // 
            lblScoreValue.AutoSize = true;
            lblScoreValue.Location = new Point(64, 67);
            lblScoreValue.Name = "lblScoreValue";
            lblScoreValue.Size = new Size(35, 15);
            lblScoreValue.TabIndex = 4;
            lblScoreValue.Text = "Value";
            // 
            // FrmWinNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(249, 134);
            Controls.Add(lblScoreValue);
            Controls.Add(btnOK);
            Controls.Add(lblScore);
            Controls.Add(lblHeader);
            Controls.Add(txtName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmWinNotification";
            Text = "Record Your Score";
            FormClosing += FrmWinNotificationFormClosingEH;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label lblHeader;
        private Label lblScore;
        private Button btnOK;
        private Label lblScoreValue;
    }
}