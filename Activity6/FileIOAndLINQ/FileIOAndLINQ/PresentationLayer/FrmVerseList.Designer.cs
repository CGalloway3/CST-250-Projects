namespace FileIOAndLINQ.PresentationLayer
{
    partial class FrmVerseList
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
            mnsFileActions = new MenuStrip();
            tsmFile = new ToolStripMenuItem();
            tsmSave = new ToolStripMenuItem();
            tsmLoad = new ToolStripMenuItem();
            tsmExit = new ToolStripMenuItem();
            grpAddVerse = new GroupBox();
            lblImportanceError = new Label();
            lblMeaningError = new Label();
            lblTextError = new Label();
            lblVerseError = new Label();
            lblChapterError = new Label();
            lblBookError = new Label();
            btnAddVerse = new Button();
            nudVerseImportance = new NumericUpDown();
            txtVerseMeaning = new TextBox();
            txtVerseText = new TextBox();
            txtVerseVerse = new TextBox();
            txtVerseChapter = new TextBox();
            cmbVerseBook = new ComboBox();
            lblImportance = new Label();
            lblMeaning = new Label();
            lblText = new Label();
            lblVerse = new Label();
            lblChapter = new Label();
            lblBook = new Label();
            grpFilterAndSort = new GroupBox();
            rdoShowMostImportant = new RadioButton();
            rdoShowLeastImportant = new RadioButton();
            rdoShowAll = new RadioButton();
            trbNumberToShow = new TrackBar();
            dgvVerseDisplay = new DataGridView();
            lblTotalVerses = new Label();
            lblTotalVersesValue = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            mnsFileActions.SuspendLayout();
            grpAddVerse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudVerseImportance).BeginInit();
            grpFilterAndSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbNumberToShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVerseDisplay).BeginInit();
            SuspendLayout();
            // 
            // mnsFileActions
            // 
            mnsFileActions.Items.AddRange(new ToolStripItem[] { tsmFile });
            mnsFileActions.Location = new Point(0, 0);
            mnsFileActions.Name = "mnsFileActions";
            mnsFileActions.Size = new Size(800, 24);
            mnsFileActions.TabIndex = 0;
            mnsFileActions.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            tsmFile.DropDownItems.AddRange(new ToolStripItem[] { tsmSave, tsmLoad, tsmExit });
            tsmFile.Name = "tsmFile";
            tsmFile.Size = new Size(37, 20);
            tsmFile.Text = "File";
            // 
            // tsmSave
            // 
            tsmSave.Name = "tsmSave";
            tsmSave.Size = new Size(180, 22);
            tsmSave.Text = "Save";
            tsmSave.Click += TsmSaveClickEH;
            // 
            // tsmLoad
            // 
            tsmLoad.Name = "tsmLoad";
            tsmLoad.Size = new Size(180, 22);
            tsmLoad.Text = "Load";
            tsmLoad.Click += TsmLoadClickEH;
            // 
            // tsmExit
            // 
            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(180, 22);
            tsmExit.Text = "Exit";
            tsmExit.Click += TsmExitClickEH;
            // 
            // grpAddVerse
            // 
            grpAddVerse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpAddVerse.Controls.Add(lblImportanceError);
            grpAddVerse.Controls.Add(lblMeaningError);
            grpAddVerse.Controls.Add(lblTextError);
            grpAddVerse.Controls.Add(lblVerseError);
            grpAddVerse.Controls.Add(lblChapterError);
            grpAddVerse.Controls.Add(lblBookError);
            grpAddVerse.Controls.Add(btnAddVerse);
            grpAddVerse.Controls.Add(nudVerseImportance);
            grpAddVerse.Controls.Add(txtVerseMeaning);
            grpAddVerse.Controls.Add(txtVerseText);
            grpAddVerse.Controls.Add(txtVerseVerse);
            grpAddVerse.Controls.Add(txtVerseChapter);
            grpAddVerse.Controls.Add(cmbVerseBook);
            grpAddVerse.Controls.Add(lblImportance);
            grpAddVerse.Controls.Add(lblMeaning);
            grpAddVerse.Controls.Add(lblText);
            grpAddVerse.Controls.Add(lblVerse);
            grpAddVerse.Controls.Add(lblChapter);
            grpAddVerse.Controls.Add(lblBook);
            grpAddVerse.Location = new Point(12, 27);
            grpAddVerse.Name = "grpAddVerse";
            grpAddVerse.Size = new Size(284, 404);
            grpAddVerse.TabIndex = 1;
            grpAddVerse.TabStop = false;
            grpAddVerse.Text = "Add A Bible Verse";
            // 
            // lblImportanceError
            // 
            lblImportanceError.AutoSize = true;
            lblImportanceError.ForeColor = Color.Red;
            lblImportanceError.Location = new Point(83, 348);
            lblImportanceError.Name = "lblImportanceError";
            lblImportanceError.Size = new Size(96, 15);
            lblImportanceError.TabIndex = 18;
            lblImportanceError.Text = "Importance Error";
            lblImportanceError.Leave += NudVerseImportanceLeaveEH;
            // 
            // lblMeaningError
            // 
            lblMeaningError.AutoSize = true;
            lblMeaningError.ForeColor = Color.Red;
            lblMeaningError.Location = new Point(83, 304);
            lblMeaningError.Name = "lblMeaningError";
            lblMeaningError.Size = new Size(82, 15);
            lblMeaningError.TabIndex = 17;
            lblMeaningError.Text = "Meaning Error";
            // 
            // lblTextError
            // 
            lblTextError.AutoSize = true;
            lblTextError.ForeColor = Color.Red;
            lblTextError.Location = new Point(83, 223);
            lblTextError.Name = "lblTextError";
            lblTextError.Size = new Size(56, 15);
            lblTextError.TabIndex = 16;
            lblTextError.Text = "Text Error";
            // 
            // lblVerseError
            // 
            lblVerseError.AutoSize = true;
            lblVerseError.ForeColor = Color.Red;
            lblVerseError.Location = new Point(83, 142);
            lblVerseError.Name = "lblVerseError";
            lblVerseError.Size = new Size(62, 15);
            lblVerseError.TabIndex = 15;
            lblVerseError.Text = "Verse Error";
            // 
            // lblChapterError
            // 
            lblChapterError.AutoSize = true;
            lblChapterError.ForeColor = Color.Red;
            lblChapterError.Location = new Point(83, 98);
            lblChapterError.Name = "lblChapterError";
            lblChapterError.Size = new Size(77, 15);
            lblChapterError.TabIndex = 14;
            lblChapterError.Text = "Chapter Error";
            // 
            // lblBookError
            // 
            lblBookError.AutoSize = true;
            lblBookError.ForeColor = Color.Red;
            lblBookError.Location = new Point(83, 54);
            lblBookError.Name = "lblBookError";
            lblBookError.Size = new Size(62, 15);
            lblBookError.TabIndex = 13;
            lblBookError.Text = "Book Error";
            // 
            // btnAddVerse
            // 
            btnAddVerse.Location = new Point(103, 369);
            btnAddVerse.Name = "btnAddVerse";
            btnAddVerse.Size = new Size(75, 23);
            btnAddVerse.TabIndex = 12;
            btnAddVerse.Text = "Add";
            btnAddVerse.UseVisualStyleBackColor = true;
            btnAddVerse.Click += BtnAddVerseClickEH;
            // 
            // nudVerseImportance
            // 
            nudVerseImportance.Location = new Point(81, 322);
            nudVerseImportance.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudVerseImportance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudVerseImportance.Name = "nudVerseImportance";
            nudVerseImportance.Size = new Size(189, 23);
            nudVerseImportance.TabIndex = 11;
            nudVerseImportance.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudVerseImportance.Leave += NudVerseImportanceLeaveEH;
            // 
            // txtVerseMeaning
            // 
            txtVerseMeaning.Location = new Point(81, 241);
            txtVerseMeaning.Multiline = true;
            txtVerseMeaning.Name = "txtVerseMeaning";
            txtVerseMeaning.Size = new Size(189, 60);
            txtVerseMeaning.TabIndex = 10;
            txtVerseMeaning.Leave += TxtVerseMeaningLeaveEH;
            // 
            // txtVerseText
            // 
            txtVerseText.Location = new Point(81, 160);
            txtVerseText.Multiline = true;
            txtVerseText.Name = "txtVerseText";
            txtVerseText.Size = new Size(189, 60);
            txtVerseText.TabIndex = 9;
            txtVerseText.Leave += TxtVerseTextLeaveEH;
            // 
            // txtVerseVerse
            // 
            txtVerseVerse.Location = new Point(81, 116);
            txtVerseVerse.Name = "txtVerseVerse";
            txtVerseVerse.Size = new Size(189, 23);
            txtVerseVerse.TabIndex = 8;
            txtVerseVerse.Leave += TxtVerseVerseLeaveEH;
            // 
            // txtVerseChapter
            // 
            txtVerseChapter.Location = new Point(83, 72);
            txtVerseChapter.Name = "txtVerseChapter";
            txtVerseChapter.Size = new Size(189, 23);
            txtVerseChapter.TabIndex = 7;
            txtVerseChapter.Leave += TxtVerseChapterLeaveEH;
            // 
            // cmbVerseBook
            // 
            cmbVerseBook.FormattingEnabled = true;
            cmbVerseBook.Location = new Point(81, 28);
            cmbVerseBook.Name = "cmbVerseBook";
            cmbVerseBook.Size = new Size(189, 23);
            cmbVerseBook.TabIndex = 6;
            cmbVerseBook.Leave += CmbVerseBookLeaveEH;
            // 
            // lblImportance
            // 
            lblImportance.AutoSize = true;
            lblImportance.Location = new Point(8, 324);
            lblImportance.Name = "lblImportance";
            lblImportance.Size = new Size(71, 15);
            lblImportance.TabIndex = 5;
            lblImportance.Text = "Importance:";
            lblImportance.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMeaning
            // 
            lblMeaning.AutoSize = true;
            lblMeaning.Location = new Point(22, 244);
            lblMeaning.Name = "lblMeaning";
            lblMeaning.Size = new Size(57, 15);
            lblMeaning.TabIndex = 4;
            lblMeaning.Text = "Meaning:";
            lblMeaning.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Location = new Point(48, 163);
            lblText.Name = "lblText";
            lblText.Size = new Size(31, 15);
            lblText.TabIndex = 3;
            lblText.Text = "Text:";
            lblText.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblVerse
            // 
            lblVerse.AutoSize = true;
            lblVerse.Location = new Point(42, 119);
            lblVerse.Name = "lblVerse";
            lblVerse.Size = new Size(37, 15);
            lblVerse.TabIndex = 2;
            lblVerse.Text = "Verse:";
            lblVerse.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblChapter
            // 
            lblChapter.AutoSize = true;
            lblChapter.Location = new Point(27, 75);
            lblChapter.Name = "lblChapter";
            lblChapter.Size = new Size(52, 15);
            lblChapter.TabIndex = 1;
            lblChapter.Text = "Chapter:";
            lblChapter.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Location = new Point(42, 31);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(37, 15);
            lblBook.TabIndex = 0;
            lblBook.Text = "Book:";
            lblBook.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpFilterAndSort
            // 
            grpFilterAndSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpFilterAndSort.Controls.Add(rdoShowMostImportant);
            grpFilterAndSort.Controls.Add(rdoShowLeastImportant);
            grpFilterAndSort.Controls.Add(rdoShowAll);
            grpFilterAndSort.Location = new Point(12, 437);
            grpFilterAndSort.Name = "grpFilterAndSort";
            grpFilterAndSort.Size = new Size(284, 140);
            grpFilterAndSort.TabIndex = 2;
            grpFilterAndSort.TabStop = false;
            grpFilterAndSort.Text = "Filter And Sort";
            // 
            // rdoShowMostImportant
            // 
            rdoShowMostImportant.AutoSize = true;
            rdoShowMostImportant.Location = new Point(19, 98);
            rdoShowMostImportant.Name = "rdoShowMostImportant";
            rdoShowMostImportant.Size = new Size(149, 19);
            rdoShowMostImportant.TabIndex = 2;
            rdoShowMostImportant.Text = "Show 0 Most Important";
            rdoShowMostImportant.UseVisualStyleBackColor = true;
            rdoShowMostImportant.CheckedChanged += RdoShowMostImportantCheckChangedEH;
            // 
            // rdoShowLeastImportant
            // 
            rdoShowLeastImportant.AutoSize = true;
            rdoShowLeastImportant.Location = new Point(19, 65);
            rdoShowLeastImportant.Name = "rdoShowLeastImportant";
            rdoShowLeastImportant.Size = new Size(149, 19);
            rdoShowLeastImportant.TabIndex = 1;
            rdoShowLeastImportant.Text = "Show 0 Least Important";
            rdoShowLeastImportant.UseVisualStyleBackColor = true;
            rdoShowLeastImportant.CheckedChanged += RdoShowLeastImportantCheckChangedEH;
            // 
            // rdoShowAll
            // 
            rdoShowAll.AutoSize = true;
            rdoShowAll.Checked = true;
            rdoShowAll.Location = new Point(19, 32);
            rdoShowAll.Name = "rdoShowAll";
            rdoShowAll.Size = new Size(71, 19);
            rdoShowAll.TabIndex = 0;
            rdoShowAll.TabStop = true;
            rdoShowAll.Text = "Show All";
            rdoShowAll.UseVisualStyleBackColor = true;
            rdoShowAll.CheckedChanged += RdoShowAllCheckedChangedEH;
            // 
            // trbNumberToShow
            // 
            trbNumberToShow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            trbNumberToShow.LargeChange = 1;
            trbNumberToShow.Location = new Point(12, 586);
            trbNumberToShow.Name = "trbNumberToShow";
            trbNumberToShow.Size = new Size(284, 45);
            trbNumberToShow.TabIndex = 3;
            trbNumberToShow.Scroll += TrbNumberToShowScrollEH;
            // 
            // dgvVerseDisplay
            // 
            dgvVerseDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVerseDisplay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVerseDisplay.Location = new Point(302, 27);
            dgvVerseDisplay.Name = "dgvVerseDisplay";
            dgvVerseDisplay.Size = new Size(486, 545);
            dgvVerseDisplay.TabIndex = 4;
            // 
            // lblTotalVerses
            // 
            lblTotalVerses.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalVerses.AutoSize = true;
            lblTotalVerses.Location = new Point(308, 590);
            lblTotalVerses.Name = "lblTotalVerses";
            lblTotalVerses.Size = new Size(134, 15);
            lblTotalVerses.TabIndex = 5;
            lblTotalVerses.Text = "Total Number Of Verses:";
            // 
            // lblTotalVersesValue
            // 
            lblTotalVersesValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalVersesValue.AutoSize = true;
            lblTotalVersesValue.Location = new Point(440, 591);
            lblTotalVersesValue.Name = "lblTotalVersesValue";
            lblTotalVersesValue.Size = new Size(13, 15);
            lblTotalVersesValue.TabIndex = 6;
            lblTotalVersesValue.Text = "0";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtSearch.Location = new Point(480, 587);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search...";
            txtSearch.Size = new Size(227, 23);
            txtSearch.TabIndex = 7;
            txtSearch.KeyDown += TxtSearchKeyDownEH;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearch.Location = new Point(713, 588);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearchClickEH;
            // 
            // FrmVerseList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 624);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblTotalVersesValue);
            Controls.Add(lblTotalVerses);
            Controls.Add(dgvVerseDisplay);
            Controls.Add(trbNumberToShow);
            Controls.Add(grpFilterAndSort);
            Controls.Add(grpAddVerse);
            Controls.Add(mnsFileActions);
            MainMenuStrip = mnsFileActions;
            Name = "FrmVerseList";
            Text = "Bible Verses";
            Load += FrmVerseListLoadEH;
            Resize += FrmVerseListResizeEH;
            mnsFileActions.ResumeLayout(false);
            mnsFileActions.PerformLayout();
            grpAddVerse.ResumeLayout(false);
            grpAddVerse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudVerseImportance).EndInit();
            grpFilterAndSort.ResumeLayout(false);
            grpFilterAndSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbNumberToShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVerseDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsFileActions;
        private ToolStripMenuItem tsmFile;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmLoad;
        private ToolStripMenuItem tsmExit;
        private GroupBox grpAddVerse;
        private TextBox txtVerseVerse;
        private TextBox txtVerseChapter;
        private ComboBox cmbVerseBook;
        private Label lblImportance;
        private Label lblMeaning;
        private Label lblText;
        private Label lblVerse;
        private Label lblChapter;
        private Label lblBook;
        private TextBox txtVerseMeaning;
        private TextBox txtVerseText;
        private Button btnAddVerse;
        private NumericUpDown nudVerseImportance;
        private Label lblImportanceError;
        private Label lblMeaningError;
        private Label lblTextError;
        private Label lblVerseError;
        private Label lblChapterError;
        private Label lblBookError;
        private GroupBox grpFilterAndSort;
        private RadioButton rdoShowMostImportant;
        private RadioButton rdoShowLeastImportant;
        private RadioButton rdoShowAll;
        private TrackBar trbNumberToShow;
        private DataGridView dgvVerseDisplay;
        private Label lblTotalVerses;
        private Label lblTotalVersesValue;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}