namespace WhackAMoleGUI.PresentationLayer
{
    partial class FrmSetup
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
            tsbBoardSize = new TrackBar();
            tsbTargetSize = new TrackBar();
            lblBoardSize = new Label();
            lblTargetSize = new Label();
            lblBoardSizeValue = new Label();
            lblTargetSizeValue = new Label();
            lblName = new Label();
            txtName = new TextBox();
            btnPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)tsbBoardSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tsbTargetSize).BeginInit();
            SuspendLayout();
            // 
            // tsbBoardSize
            // 
            tsbBoardSize.LargeChange = 1;
            tsbBoardSize.Location = new Point(20, 98);
            tsbBoardSize.Maximum = 2;
            tsbBoardSize.Name = "tsbBoardSize";
            tsbBoardSize.Size = new Size(220, 45);
            tsbBoardSize.TabIndex = 2;
            tsbBoardSize.Scroll += TsbBoardSizeScrollEH;
            // 
            // tsbTargetSize
            // 
            tsbTargetSize.LargeChange = 1;
            tsbTargetSize.Location = new Point(20, 173);
            tsbTargetSize.Maximum = 2;
            tsbTargetSize.Name = "tsbTargetSize";
            tsbTargetSize.Size = new Size(220, 45);
            tsbTargetSize.TabIndex = 3;
            tsbTargetSize.Scroll += TsbTargetSizeScrollEH;
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(21, 71);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(61, 15);
            lblBoardSize.TabIndex = 0;
            lblBoardSize.Text = "BoardSize:";
            // 
            // lblTargetSize
            // 
            lblTargetSize.AutoSize = true;
            lblTargetSize.Location = new Point(16, 150);
            lblTargetSize.Name = "lblTargetSize";
            lblTargetSize.Size = new Size(66, 15);
            lblTargetSize.TabIndex = 0;
            lblTargetSize.Text = "Target Size:";
            // 
            // lblBoardSizeValue
            // 
            lblBoardSizeValue.AutoSize = true;
            lblBoardSizeValue.Location = new Point(88, 71);
            lblBoardSizeValue.Name = "lblBoardSizeValue";
            lblBoardSizeValue.Size = new Size(36, 15);
            lblBoardSizeValue.TabIndex = 0;
            lblBoardSizeValue.Text = "Small";
            // 
            // lblTargetSizeValue
            // 
            lblTargetSizeValue.AutoSize = true;
            lblTargetSizeValue.Location = new Point(88, 150);
            lblTargetSizeValue.Name = "lblTargetSizeValue";
            lblTargetSizeValue.Size = new Size(36, 15);
            lblTargetSizeValue.TabIndex = 0;
            lblTargetSizeValue.Text = "Large";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(24, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(216, 23);
            txtName.TabIndex = 1;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(84, 218);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += BtnPlayClickEH;
            // 
            // FrmSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 268);
            ControlBox = false;
            Controls.Add(btnPlay);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblTargetSizeValue);
            Controls.Add(lblBoardSizeValue);
            Controls.Add(lblTargetSize);
            Controls.Add(lblBoardSize);
            Controls.Add(tsbTargetSize);
            Controls.Add(tsbBoardSize);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FrmSetup";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Setup Game";
            FormClosing += FrmSetupFormClosingEH;
            ((System.ComponentModel.ISupportInitialize)tsbBoardSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)tsbTargetSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar tsbBoardSize;
        private TrackBar tsbTargetSize;
        private Label lblBoardSize;
        private Label lblTargetSize;
        private Label lblBoardSizeValue;
        private Label lblTargetSizeValue;
        private Label lblName;
        private TextBox txtName;
        private Button btnPlay;
    }
}