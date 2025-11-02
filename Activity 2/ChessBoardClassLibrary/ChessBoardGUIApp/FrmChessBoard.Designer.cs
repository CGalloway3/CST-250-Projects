namespace ChessBoardGUIApp
{
    partial class FrmChessBoard
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
            cmbChessPieces = new ComboBox();
            lblDescription = new Label();
            lblPiece = new Label();
            pnlChessBoard = new Panel();
            cmbColor = new ComboBox();
            lblColor = new Label();
            colorDialog = new ColorDialog();
            gbPiecePicker = new GroupBox();
            gbColorPicker = new GroupBox();
            pnlPalette3 = new Panel();
            btnPalette3_2 = new Button();
            btnPalette3_1 = new Button();
            btnPalette3_3 = new Button();
            btnPalette3_4 = new Button();
            pnlPalette4 = new Panel();
            btnPalette4_2 = new Button();
            btnPalette4_1 = new Button();
            btnPalette4_3 = new Button();
            btnPalette4_4 = new Button();
            pnlPalette6 = new Panel();
            btnPalette6_2 = new Button();
            btnPalette6_1 = new Button();
            btnPalette6_3 = new Button();
            btnPalette6_4 = new Button();
            pnlPalette5 = new Panel();
            btnPalette5_2 = new Button();
            btnPalette5_1 = new Button();
            btnPalette5_3 = new Button();
            btnPalette5_4 = new Button();
            pnlPalette2 = new Panel();
            btnPalette2_2 = new Button();
            btnPalette2_1 = new Button();
            btnPalette2_3 = new Button();
            btnPalette2_4 = new Button();
            pnlPalette1 = new Panel();
            btnPalette1_2 = new Button();
            btnPalette1_1 = new Button();
            btnPalette1_3 = new Button();
            btnPalette1_4 = new Button();
            gbCustomColors = new GroupBox();
            btnCustomWhite = new Button();
            btnCustomBlack = new Button();
            pnlPaletteCustom = new Panel();
            btnCustom2 = new Button();
            btnCustom1 = new Button();
            btnCustom3 = new Button();
            btnCustom4 = new Button();
            gbPiecePicker.SuspendLayout();
            gbColorPicker.SuspendLayout();
            pnlPalette3.SuspendLayout();
            pnlPalette4.SuspendLayout();
            pnlPalette6.SuspendLayout();
            pnlPalette5.SuspendLayout();
            pnlPalette2.SuspendLayout();
            pnlPalette1.SuspendLayout();
            gbCustomColors.SuspendLayout();
            pnlPaletteCustom.SuspendLayout();
            SuspendLayout();
            // 
            // cmbChessPieces
            // 
            cmbChessPieces.FormattingEnabled = true;
            cmbChessPieces.Items.AddRange(new object[] { "None", "King", "Queen", "Bishop", "Knight", "Rook", "Pawn" });
            cmbChessPieces.Location = new Point(69, 22);
            cmbChessPieces.Name = "cmbChessPieces";
            cmbChessPieces.Size = new Size(101, 23);
            cmbChessPieces.TabIndex = 0;
            cmbChessPieces.Text = "None (Delete)";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(21, 12);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(394, 15);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Select a chess piece and its location on the board and see the legal moves";
            // 
            // lblPiece
            // 
            lblPiece.AutoSize = true;
            lblPiece.Location = new Point(20, 25);
            lblPiece.Name = "lblPiece";
            lblPiece.Size = new Size(38, 15);
            lblPiece.TabIndex = 2;
            lblPiece.Text = "Piece:";
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChessBoard.Location = new Point(12, 30);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(500, 500);
            pnlChessBoard.TabIndex = 3;
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "None", "Black", "White" });
            cmbColor.Location = new Point(69, 51);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(101, 23);
            cmbColor.TabIndex = 4;
            cmbColor.Text = "Black";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(24, 54);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(39, 15);
            lblColor.TabIndex = 5;
            lblColor.Text = "Color:";
            // 
            // gbPiecePicker
            // 
            gbPiecePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPiecePicker.Controls.Add(cmbChessPieces);
            gbPiecePicker.Controls.Add(lblColor);
            gbPiecePicker.Controls.Add(cmbColor);
            gbPiecePicker.Controls.Add(lblPiece);
            gbPiecePicker.Location = new Point(522, 12);
            gbPiecePicker.Name = "gbPiecePicker";
            gbPiecePicker.Size = new Size(189, 85);
            gbPiecePicker.TabIndex = 6;
            gbPiecePicker.TabStop = false;
            gbPiecePicker.Text = "Piece Picker";
            // 
            // gbColorPicker
            // 
            gbColorPicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbColorPicker.Controls.Add(pnlPalette3);
            gbColorPicker.Controls.Add(pnlPalette4);
            gbColorPicker.Controls.Add(pnlPalette6);
            gbColorPicker.Controls.Add(pnlPalette5);
            gbColorPicker.Controls.Add(pnlPalette2);
            gbColorPicker.Controls.Add(pnlPalette1);
            gbColorPicker.Location = new Point(518, 103);
            gbColorPicker.Name = "gbColorPicker";
            gbColorPicker.Size = new Size(193, 289);
            gbColorPicker.TabIndex = 7;
            gbColorPicker.TabStop = false;
            gbColorPicker.Text = "Board Color Picker";
            // 
            // pnlPalette3
            // 
            pnlPalette3.Controls.Add(btnPalette3_2);
            pnlPalette3.Controls.Add(btnPalette3_1);
            pnlPalette3.Controls.Add(btnPalette3_3);
            pnlPalette3.Controls.Add(btnPalette3_4);
            pnlPalette3.Location = new Point(9, 109);
            pnlPalette3.Name = "pnlPalette3";
            pnlPalette3.Size = new Size(84, 84);
            pnlPalette3.TabIndex = 13;
            pnlPalette3.Click += BtnPalette3ClickEH;
            pnlPalette3.Paint += PnlPalettePaintEH;
            // 
            // btnPalette3_2
            // 
            btnPalette3_2.BackColor = Color.FromArgb(33, 25, 26);
            btnPalette3_2.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette3_2.ForeColor = Color.Chocolate;
            btnPalette3_2.Location = new Point(43, 3);
            btnPalette3_2.Name = "btnPalette3_2";
            btnPalette3_2.Size = new Size(39, 39);
            btnPalette3_2.TabIndex = 1;
            btnPalette3_2.TabStop = false;
            btnPalette3_2.Text = "King";
            btnPalette3_2.UseVisualStyleBackColor = false;
            btnPalette3_2.Click += BtnPalette3ClickEH;
            btnPalette3_2.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette3_2.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette3_1
            // 
            btnPalette3_1.BackColor = Color.FromArgb(233, 234, 236);
            btnPalette3_1.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette3_1.ForeColor = Color.Chocolate;
            btnPalette3_1.Location = new Point(4, 3);
            btnPalette3_1.Name = "btnPalette3_1";
            btnPalette3_1.Size = new Size(39, 39);
            btnPalette3_1.TabIndex = 0;
            btnPalette3_1.TabStop = false;
            btnPalette3_1.Text = "Queen";
            btnPalette3_1.UseVisualStyleBackColor = false;
            btnPalette3_1.Click += BtnPalette3ClickEH;
            btnPalette3_1.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette3_1.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette3_3
            // 
            btnPalette3_3.BackColor = Color.FromArgb(33, 25, 26);
            btnPalette3_3.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette3_3.ForeColor = Color.FromArgb(103, 145, 159);
            btnPalette3_3.Location = new Point(4, 42);
            btnPalette3_3.Name = "btnPalette3_3";
            btnPalette3_3.Size = new Size(39, 39);
            btnPalette3_3.TabIndex = 2;
            btnPalette3_3.TabStop = false;
            btnPalette3_3.Text = "Knight";
            btnPalette3_3.UseVisualStyleBackColor = false;
            btnPalette3_3.Click += BtnPalette3ClickEH;
            btnPalette3_3.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette3_3.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette3_4
            // 
            btnPalette3_4.BackColor = Color.FromArgb(233, 234, 236);
            btnPalette3_4.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette3_4.ForeColor = Color.FromArgb(103, 145, 159);
            btnPalette3_4.Location = new Point(43, 42);
            btnPalette3_4.Name = "btnPalette3_4";
            btnPalette3_4.Size = new Size(39, 39);
            btnPalette3_4.TabIndex = 3;
            btnPalette3_4.TabStop = false;
            btnPalette3_4.Text = "Rook";
            btnPalette3_4.UseVisualStyleBackColor = false;
            btnPalette3_4.Click += BtnPalette3ClickEH;
            btnPalette3_4.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette3_4.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // pnlPalette4
            // 
            pnlPalette4.Controls.Add(btnPalette4_2);
            pnlPalette4.Controls.Add(btnPalette4_1);
            pnlPalette4.Controls.Add(btnPalette4_3);
            pnlPalette4.Controls.Add(btnPalette4_4);
            pnlPalette4.Location = new Point(99, 109);
            pnlPalette4.Name = "pnlPalette4";
            pnlPalette4.Size = new Size(84, 84);
            pnlPalette4.TabIndex = 12;
            pnlPalette4.Click += BtnPalette4ClickEH;
            pnlPalette4.Paint += PnlPalettePaintEH;
            // 
            // btnPalette4_2
            // 
            btnPalette4_2.BackColor = Color.Black;
            btnPalette4_2.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette4_2.ForeColor = Color.DodgerBlue;
            btnPalette4_2.Location = new Point(43, 3);
            btnPalette4_2.Name = "btnPalette4_2";
            btnPalette4_2.Size = new Size(39, 39);
            btnPalette4_2.TabIndex = 1;
            btnPalette4_2.TabStop = false;
            btnPalette4_2.Text = "King";
            btnPalette4_2.UseVisualStyleBackColor = false;
            btnPalette4_2.Click += BtnPalette4ClickEH;
            btnPalette4_2.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette4_2.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette4_1
            // 
            btnPalette4_1.BackColor = Color.White;
            btnPalette4_1.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette4_1.ForeColor = Color.DodgerBlue;
            btnPalette4_1.Location = new Point(4, 3);
            btnPalette4_1.Name = "btnPalette4_1";
            btnPalette4_1.Size = new Size(39, 39);
            btnPalette4_1.TabIndex = 0;
            btnPalette4_1.TabStop = false;
            btnPalette4_1.Text = "Queen";
            btnPalette4_1.UseVisualStyleBackColor = false;
            btnPalette4_1.Click += BtnPalette4ClickEH;
            btnPalette4_1.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette4_1.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette4_3
            // 
            btnPalette4_3.BackColor = Color.Black;
            btnPalette4_3.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette4_3.ForeColor = Color.Fuchsia;
            btnPalette4_3.Location = new Point(4, 42);
            btnPalette4_3.Name = "btnPalette4_3";
            btnPalette4_3.Size = new Size(39, 39);
            btnPalette4_3.TabIndex = 2;
            btnPalette4_3.TabStop = false;
            btnPalette4_3.Text = "Knight";
            btnPalette4_3.UseVisualStyleBackColor = false;
            btnPalette4_3.Click += BtnPalette4ClickEH;
            btnPalette4_3.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette4_3.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette4_4
            // 
            btnPalette4_4.BackColor = Color.White;
            btnPalette4_4.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette4_4.ForeColor = Color.Fuchsia;
            btnPalette4_4.Location = new Point(43, 42);
            btnPalette4_4.Name = "btnPalette4_4";
            btnPalette4_4.Size = new Size(39, 39);
            btnPalette4_4.TabIndex = 3;
            btnPalette4_4.TabStop = false;
            btnPalette4_4.Text = "Rook";
            btnPalette4_4.UseVisualStyleBackColor = false;
            btnPalette4_4.Click += BtnPalette4ClickEH;
            btnPalette4_4.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette4_4.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // pnlPalette6
            // 
            pnlPalette6.Controls.Add(btnPalette6_2);
            pnlPalette6.Controls.Add(btnPalette6_1);
            pnlPalette6.Controls.Add(btnPalette6_3);
            pnlPalette6.Controls.Add(btnPalette6_4);
            pnlPalette6.Location = new Point(99, 196);
            pnlPalette6.Name = "pnlPalette6";
            pnlPalette6.Size = new Size(84, 84);
            pnlPalette6.TabIndex = 11;
            pnlPalette6.Click += BtnPalette6ClickEH;
            pnlPalette6.Paint += PnlPalettePaintEH;
            // 
            // btnPalette6_2
            // 
            btnPalette6_2.BackColor = Color.FromArgb(26, 67, 20);
            btnPalette6_2.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette6_2.ForeColor = Color.FromArgb(50, 205, 48);
            btnPalette6_2.Location = new Point(43, 3);
            btnPalette6_2.Name = "btnPalette6_2";
            btnPalette6_2.Size = new Size(39, 39);
            btnPalette6_2.TabIndex = 1;
            btnPalette6_2.TabStop = false;
            btnPalette6_2.Text = "King";
            btnPalette6_2.UseVisualStyleBackColor = false;
            btnPalette6_2.Click += BtnPalette6ClickEH;
            btnPalette6_2.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette6_2.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette6_1
            // 
            btnPalette6_1.BackColor = Color.FromArgb(44, 94, 26);
            btnPalette6_1.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette6_1.ForeColor = Color.FromArgb(50, 205, 48);
            btnPalette6_1.Location = new Point(4, 3);
            btnPalette6_1.Name = "btnPalette6_1";
            btnPalette6_1.Size = new Size(39, 39);
            btnPalette6_1.TabIndex = 0;
            btnPalette6_1.TabStop = false;
            btnPalette6_1.Text = "Queen";
            btnPalette6_1.UseVisualStyleBackColor = false;
            btnPalette6_1.Click += BtnPalette6ClickEH;
            btnPalette6_1.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette6_1.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette6_3
            // 
            btnPalette6_3.BackColor = Color.FromArgb(26, 67, 20);
            btnPalette6_3.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette6_3.ForeColor = Color.FromArgb(178, 210, 164);
            btnPalette6_3.Location = new Point(4, 42);
            btnPalette6_3.Name = "btnPalette6_3";
            btnPalette6_3.Size = new Size(39, 39);
            btnPalette6_3.TabIndex = 2;
            btnPalette6_3.TabStop = false;
            btnPalette6_3.Text = "Knight";
            btnPalette6_3.UseVisualStyleBackColor = false;
            btnPalette6_3.Click += BtnPalette6ClickEH;
            btnPalette6_3.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette6_3.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette6_4
            // 
            btnPalette6_4.BackColor = Color.FromArgb(44, 94, 26);
            btnPalette6_4.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette6_4.ForeColor = Color.FromArgb(178, 210, 164);
            btnPalette6_4.Location = new Point(43, 42);
            btnPalette6_4.Name = "btnPalette6_4";
            btnPalette6_4.Size = new Size(39, 39);
            btnPalette6_4.TabIndex = 3;
            btnPalette6_4.TabStop = false;
            btnPalette6_4.Text = "Rook";
            btnPalette6_4.UseVisualStyleBackColor = false;
            btnPalette6_4.Click += BtnPalette6ClickEH;
            btnPalette6_4.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette6_4.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // pnlPalette5
            // 
            pnlPalette5.Controls.Add(btnPalette5_2);
            pnlPalette5.Controls.Add(btnPalette5_1);
            pnlPalette5.Controls.Add(btnPalette5_3);
            pnlPalette5.Controls.Add(btnPalette5_4);
            pnlPalette5.Location = new Point(9, 196);
            pnlPalette5.Name = "pnlPalette5";
            pnlPalette5.Size = new Size(84, 84);
            pnlPalette5.TabIndex = 10;
            pnlPalette5.Click += BtnPalette5ClickEH;
            pnlPalette5.Paint += PnlPalettePaintEH;
            // 
            // btnPalette5_2
            // 
            btnPalette5_2.BackColor = Color.FromArgb(142, 110, 82);
            btnPalette5_2.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette5_2.ForeColor = Color.FromArgb(45, 58, 62);
            btnPalette5_2.Location = new Point(43, 3);
            btnPalette5_2.Name = "btnPalette5_2";
            btnPalette5_2.Size = new Size(39, 39);
            btnPalette5_2.TabIndex = 1;
            btnPalette5_2.TabStop = false;
            btnPalette5_2.Text = "King";
            btnPalette5_2.UseVisualStyleBackColor = false;
            btnPalette5_2.Click += BtnPalette5ClickEH;
            btnPalette5_2.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette5_2.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette5_1
            // 
            btnPalette5_1.BackColor = Color.FromArgb(247, 230, 218);
            btnPalette5_1.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette5_1.ForeColor = Color.FromArgb(45, 58, 62);
            btnPalette5_1.Location = new Point(4, 3);
            btnPalette5_1.Name = "btnPalette5_1";
            btnPalette5_1.Size = new Size(39, 39);
            btnPalette5_1.TabIndex = 0;
            btnPalette5_1.TabStop = false;
            btnPalette5_1.Text = "Queen";
            btnPalette5_1.UseVisualStyleBackColor = false;
            btnPalette5_1.Click += BtnPalette5ClickEH;
            btnPalette5_1.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette5_1.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette5_3
            // 
            btnPalette5_3.BackColor = Color.FromArgb(142, 110, 82);
            btnPalette5_3.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette5_3.ForeColor = Color.FromArgb(76, 212, 224);
            btnPalette5_3.Location = new Point(4, 42);
            btnPalette5_3.Name = "btnPalette5_3";
            btnPalette5_3.Size = new Size(39, 39);
            btnPalette5_3.TabIndex = 2;
            btnPalette5_3.TabStop = false;
            btnPalette5_3.Text = "Knight";
            btnPalette5_3.UseVisualStyleBackColor = false;
            btnPalette5_3.Click += BtnPalette5ClickEH;
            btnPalette5_3.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette5_3.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette5_4
            // 
            btnPalette5_4.BackColor = Color.FromArgb(247, 230, 218);
            btnPalette5_4.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette5_4.ForeColor = Color.FromArgb(76, 212, 224);
            btnPalette5_4.Location = new Point(43, 42);
            btnPalette5_4.Name = "btnPalette5_4";
            btnPalette5_4.Size = new Size(39, 39);
            btnPalette5_4.TabIndex = 3;
            btnPalette5_4.TabStop = false;
            btnPalette5_4.Text = "Rook";
            btnPalette5_4.UseVisualStyleBackColor = false;
            btnPalette5_4.Click += BtnPalette5ClickEH;
            btnPalette5_4.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette5_4.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // pnlPalette2
            // 
            pnlPalette2.Controls.Add(btnPalette2_2);
            pnlPalette2.Controls.Add(btnPalette2_1);
            pnlPalette2.Controls.Add(btnPalette2_3);
            pnlPalette2.Controls.Add(btnPalette2_4);
            pnlPalette2.Location = new Point(99, 22);
            pnlPalette2.Name = "pnlPalette2";
            pnlPalette2.Size = new Size(84, 84);
            pnlPalette2.TabIndex = 9;
            pnlPalette2.Click += BtnPalette2ClickEH;
            pnlPalette2.Paint += PnlPalettePaintEH;
            // 
            // btnPalette2_2
            // 
            btnPalette2_2.BackColor = Color.Blue;
            btnPalette2_2.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette2_2.Location = new Point(43, 3);
            btnPalette2_2.Name = "btnPalette2_2";
            btnPalette2_2.Size = new Size(39, 39);
            btnPalette2_2.TabIndex = 1;
            btnPalette2_2.TabStop = false;
            btnPalette2_2.Text = "King";
            btnPalette2_2.UseVisualStyleBackColor = false;
            btnPalette2_2.Click += BtnPalette2ClickEH;
            btnPalette2_2.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette2_2.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette2_1
            // 
            btnPalette2_1.BackColor = Color.SandyBrown;
            btnPalette2_1.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette2_1.Location = new Point(4, 3);
            btnPalette2_1.Name = "btnPalette2_1";
            btnPalette2_1.Size = new Size(39, 39);
            btnPalette2_1.TabIndex = 0;
            btnPalette2_1.TabStop = false;
            btnPalette2_1.Text = "Queen";
            btnPalette2_1.UseVisualStyleBackColor = false;
            btnPalette2_1.Click += BtnPalette2ClickEH;
            btnPalette2_1.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette2_1.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette2_3
            // 
            btnPalette2_3.BackColor = Color.Blue;
            btnPalette2_3.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette2_3.ForeColor = Color.Ivory;
            btnPalette2_3.Location = new Point(4, 42);
            btnPalette2_3.Name = "btnPalette2_3";
            btnPalette2_3.Size = new Size(39, 39);
            btnPalette2_3.TabIndex = 2;
            btnPalette2_3.TabStop = false;
            btnPalette2_3.Text = "Knight";
            btnPalette2_3.UseVisualStyleBackColor = false;
            btnPalette2_3.Click += BtnPalette2ClickEH;
            btnPalette2_3.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette2_3.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette2_4
            // 
            btnPalette2_4.BackColor = Color.SandyBrown;
            btnPalette2_4.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette2_4.ForeColor = Color.Ivory;
            btnPalette2_4.Location = new Point(43, 42);
            btnPalette2_4.Name = "btnPalette2_4";
            btnPalette2_4.Size = new Size(39, 39);
            btnPalette2_4.TabIndex = 3;
            btnPalette2_4.TabStop = false;
            btnPalette2_4.Text = "Rook";
            btnPalette2_4.UseVisualStyleBackColor = false;
            btnPalette2_4.Click += BtnPalette2ClickEH;
            btnPalette2_4.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette2_4.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // pnlPalette1
            // 
            pnlPalette1.Controls.Add(btnPalette1_2);
            pnlPalette1.Controls.Add(btnPalette1_1);
            pnlPalette1.Controls.Add(btnPalette1_3);
            pnlPalette1.Controls.Add(btnPalette1_4);
            pnlPalette1.Location = new Point(9, 22);
            pnlPalette1.Name = "pnlPalette1";
            pnlPalette1.Size = new Size(84, 84);
            pnlPalette1.TabIndex = 8;
            pnlPalette1.Click += BtnPalette1ClickEH;
            pnlPalette1.Paint += PnlPalettePaintEH;
            // 
            // btnPalette1_2
            // 
            btnPalette1_2.BackColor = Color.FromArgb(201, 141, 38);
            btnPalette1_2.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette1_2.Location = new Point(43, 3);
            btnPalette1_2.Name = "btnPalette1_2";
            btnPalette1_2.Size = new Size(39, 39);
            btnPalette1_2.TabIndex = 1;
            btnPalette1_2.TabStop = false;
            btnPalette1_2.Text = "King";
            btnPalette1_2.UseVisualStyleBackColor = false;
            btnPalette1_2.Click += BtnPalette1ClickEH;
            btnPalette1_2.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette1_2.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette1_1
            // 
            btnPalette1_1.BackColor = Color.FromArgb(10, 186, 181);
            btnPalette1_1.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette1_1.Location = new Point(4, 3);
            btnPalette1_1.Name = "btnPalette1_1";
            btnPalette1_1.Size = new Size(39, 39);
            btnPalette1_1.TabIndex = 0;
            btnPalette1_1.TabStop = false;
            btnPalette1_1.Text = "Queen";
            btnPalette1_1.UseVisualStyleBackColor = false;
            btnPalette1_1.Click += BtnPalette1ClickEH;
            btnPalette1_1.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette1_1.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette1_3
            // 
            btnPalette1_3.BackColor = Color.FromArgb(201, 141, 38);
            btnPalette1_3.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette1_3.ForeColor = Color.Ivory;
            btnPalette1_3.Location = new Point(4, 42);
            btnPalette1_3.Name = "btnPalette1_3";
            btnPalette1_3.Size = new Size(39, 39);
            btnPalette1_3.TabIndex = 2;
            btnPalette1_3.TabStop = false;
            btnPalette1_3.Text = "Knight";
            btnPalette1_3.UseVisualStyleBackColor = false;
            btnPalette1_3.Click += BtnPalette1ClickEH;
            btnPalette1_3.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette1_3.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // btnPalette1_4
            // 
            btnPalette1_4.BackColor = Color.FromArgb(10, 186, 181);
            btnPalette1_4.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
            btnPalette1_4.ForeColor = Color.Ivory;
            btnPalette1_4.Location = new Point(43, 42);
            btnPalette1_4.Name = "btnPalette1_4";
            btnPalette1_4.Size = new Size(39, 39);
            btnPalette1_4.TabIndex = 3;
            btnPalette1_4.TabStop = false;
            btnPalette1_4.Text = "Rook";
            btnPalette1_4.UseVisualStyleBackColor = false;
            btnPalette1_4.Click += BtnPalette1ClickEH;
            btnPalette1_4.MouseEnter += BtnPaletteMouseEnterEH;
            btnPalette1_4.MouseLeave += BtnPaletteMouseLeaveEH;
            // 
            // gbCustomColors
            // 
            gbCustomColors.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbCustomColors.Controls.Add(btnCustomWhite);
            gbCustomColors.Controls.Add(btnCustomBlack);
            gbCustomColors.Controls.Add(pnlPaletteCustom);
            gbCustomColors.Location = new Point(518, 398);
            gbCustomColors.Name = "gbCustomColors";
            gbCustomColors.Size = new Size(193, 132);
            gbCustomColors.TabIndex = 8;
            gbCustomColors.TabStop = false;
            gbCustomColors.Text = "Custom Colors";
            // 
            // btnCustomWhite
            // 
            btnCustomWhite.ForeColor = Color.Fuchsia;
            btnCustomWhite.Location = new Point(116, 73);
            btnCustomWhite.Name = "btnCustomWhite";
            btnCustomWhite.Size = new Size(70, 50);
            btnCustomWhite.TabIndex = 16;
            btnCustomWhite.Text = "Piece Two Color";
            btnCustomWhite.UseVisualStyleBackColor = true;
            btnCustomWhite.Click += BtnPieceTwoColorClickEH;
            // 
            // btnCustomBlack
            // 
            btnCustomBlack.ForeColor = Color.DodgerBlue;
            btnCustomBlack.Location = new Point(116, 23);
            btnCustomBlack.Name = "btnCustomBlack";
            btnCustomBlack.Size = new Size(70, 50);
            btnCustomBlack.TabIndex = 13;
            btnCustomBlack.Text = "Piece One Color";
            btnCustomBlack.UseVisualStyleBackColor = true;
            btnCustomBlack.Click += BtnPieceOneColorClickEH;
            // 
            // pnlPaletteCustom
            // 
            pnlPaletteCustom.Controls.Add(btnCustom2);
            pnlPaletteCustom.Controls.Add(btnCustom1);
            pnlPaletteCustom.Controls.Add(btnCustom3);
            pnlPaletteCustom.Controls.Add(btnCustom4);
            pnlPaletteCustom.Location = new Point(9, 22);
            pnlPaletteCustom.Name = "pnlPaletteCustom";
            pnlPaletteCustom.Size = new Size(102, 102);
            pnlPaletteCustom.TabIndex = 9;
            // 
            // btnCustom2
            // 
            btnCustom2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCustom2.AutoSize = true;
            btnCustom2.BackColor = Color.Black;
            btnCustom2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnCustom2.ForeColor = Color.DodgerBlue;
            btnCustom2.Location = new Point(51, 1);
            btnCustom2.Name = "btnCustom2";
            btnCustom2.Size = new Size(50, 50);
            btnCustom2.TabIndex = 1;
            btnCustom2.Text = "King";
            btnCustom2.UseVisualStyleBackColor = false;
            btnCustom2.Click += BtnCustom2ClickEH;
            // 
            // btnCustom1
            // 
            btnCustom1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCustom1.AutoSize = true;
            btnCustom1.BackColor = Color.White;
            btnCustom1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnCustom1.ForeColor = Color.DodgerBlue;
            btnCustom1.Location = new Point(1, 1);
            btnCustom1.Name = "btnCustom1";
            btnCustom1.Size = new Size(51, 50);
            btnCustom1.TabIndex = 0;
            btnCustom1.Text = "Queen";
            btnCustom1.UseVisualStyleBackColor = false;
            btnCustom1.Click += BtnCustom1ClickEH;
            // 
            // btnCustom3
            // 
            btnCustom3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCustom3.AutoSize = true;
            btnCustom3.BackColor = Color.Black;
            btnCustom3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnCustom3.ForeColor = Color.Fuchsia;
            btnCustom3.Location = new Point(1, 51);
            btnCustom3.Name = "btnCustom3";
            btnCustom3.Size = new Size(52, 50);
            btnCustom3.TabIndex = 2;
            btnCustom3.Text = "Knight";
            btnCustom3.UseVisualStyleBackColor = false;
            btnCustom3.Click += BtnCustom2ClickEH;
            // 
            // btnCustom4
            // 
            btnCustom4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCustom4.AutoSize = true;
            btnCustom4.BackColor = Color.White;
            btnCustom4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnCustom4.ForeColor = Color.Fuchsia;
            btnCustom4.Location = new Point(51, 51);
            btnCustom4.Name = "btnCustom4";
            btnCustom4.Size = new Size(50, 50);
            btnCustom4.TabIndex = 3;
            btnCustom4.Text = "Rook";
            btnCustom4.UseVisualStyleBackColor = false;
            btnCustom4.Click += BtnCustom1ClickEH;
            // 
            // FrmChessBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 538);
            Controls.Add(gbCustomColors);
            Controls.Add(gbColorPicker);
            Controls.Add(gbPiecePicker);
            Controls.Add(pnlChessBoard);
            Controls.Add(lblDescription);
            Name = "FrmChessBoard";
            Text = "Chess Board";
            gbPiecePicker.ResumeLayout(false);
            gbPiecePicker.PerformLayout();
            gbColorPicker.ResumeLayout(false);
            pnlPalette3.ResumeLayout(false);
            pnlPalette4.ResumeLayout(false);
            pnlPalette6.ResumeLayout(false);
            pnlPalette5.ResumeLayout(false);
            pnlPalette2.ResumeLayout(false);
            pnlPalette1.ResumeLayout(false);
            gbCustomColors.ResumeLayout(false);
            pnlPaletteCustom.ResumeLayout(false);
            pnlPaletteCustom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbChessPieces;
        private Label lblDescription;
        private Label lblPiece;
        private Panel pnlChessBoard;
        private ComboBox cmbColor;
        private Label lblColor;
        private ColorDialog colorDialog;
        private GroupBox gbPiecePicker;
        private GroupBox gbColorPicker;
        private Button btnPalette1_4;
        private Button btnPalette1_3;
        private Button btnPalette1_2;
        private Button btnPalette1_1;
        private Panel pnlPalette1;
        private Panel pnlPalette3;
        private Button btnPalette3_2;
        private Button btnPalette3_1;
        private Button btnPalette3_3;
        private Button btnPalette3_4;
        private Panel pnlPalette4;
        private Button btnPalette4_2;
        private Button btnPalette4_1;
        private Panel pnlPalette6;
        private Button btnPalette6_2;
        private Button btnPalette6_1;
        private Button btnPalette6_3;
        private Button btnPalette6_4;
        private Button btnPalette4_3;
        private Button btnPalette4_4;
        private Panel pnlPalette5;
        private Button btnPalette5_2;
        private Button btnPalette5_1;
        private Button btnPalette5_3;
        private Button btnPalette5_4;
        private Panel pnlPalette2;
        private Button btnPalette2_2;
        private Button btnPalette2_1;
        private Button btnPalette2_3;
        private Button btnPalette2_4;
        private GroupBox gbCustomColors;
        private Button btnCustomBlack;
        private Panel pnlPaletteCustom;
        private Button btnCustom2;
        private Button btnCustom1;
        private Button btnCustom3;
        private Button btnCustom4;
        private Button btnCustomWhite;
    }
}
