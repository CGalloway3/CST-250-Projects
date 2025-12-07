namespace Quiz_question_4
{
    partial class FrmMain
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
            lblEnter = new Label();
            txtNumber = new TextBox();
            lblCount = new Label();
            tmrCounter = new System.Windows.Forms.Timer(components);
            btnStart = new Button();
            SuspendLayout();
            // 
            // lblEnter
            // 
            lblEnter.AccessibleRole = AccessibleRole.None;
            lblEnter.AutoSize = true;
            lblEnter.Location = new Point(18, 15);
            lblEnter.Name = "lblEnter";
            lblEnter.Size = new Size(90, 15);
            lblEnter.TabIndex = 0;
            lblEnter.Text = "Enter a Number";
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(114, 12);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(100, 23);
            txtNumber.TabIndex = 1;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCount.Location = new Point(54, 83);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(27, 32);
            lblCount.TabIndex = 2;
            lblCount.Text = "0";
            // 
            // tmrCounter
            // 
            tmrCounter.Interval = 500;
            tmrCounter.Tick += TmrCounterTickEH;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(76, 44);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStartClickEH;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(227, 134);
            Controls.Add(btnStart);
            Controls.Add(lblCount);
            Controls.Add(txtNumber);
            Controls.Add(lblEnter);
            Name = "FrmMain";
            Text = "Main Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEnter;
        private TextBox txtNumber;
        private Label lblCount;
        private System.Windows.Forms.Timer tmrCounter;
        private Button btnStart;
    }
}
