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
            SuspendLayout();
            // 
            // cmbChessPieces
            // 
            cmbChessPieces.FormattingEnabled = true;
            cmbChessPieces.Items.AddRange(new object[] { "King", "Queen", "Bishop", "Knight", "Rook", "Pawn" });
            cmbChessPieces.Location = new Point(564, 19);
            cmbChessPieces.Name = "cmbChessPieces";
            cmbChessPieces.Size = new Size(121, 23);
            cmbChessPieces.TabIndex = 0;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(18, 22);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(394, 15);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Select a chess piece and its location on the board and see the legal moves";
            // 
            // lblPiece
            // 
            lblPiece.AutoSize = true;
            lblPiece.Location = new Point(515, 22);
            lblPiece.Name = "lblPiece";
            lblPiece.Size = new Size(43, 15);
            lblPiece.TabIndex = 2;
            lblPiece.Text = "Pieces:";
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.Location = new Point(18, 51);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(500, 500);
            pnlChessBoard.TabIndex = 3;
            // 
            // FrmChessBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 572);
            Controls.Add(pnlChessBoard);
            Controls.Add(lblPiece);
            Controls.Add(lblDescription);
            Controls.Add(cmbChessPieces);
            Name = "FrmChessBoard";
            Text = "Chess Board";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbChessPieces;
        private Label lblDescription;
        private Label lblPiece;
        private Panel pnlChessBoard;
    }
}
