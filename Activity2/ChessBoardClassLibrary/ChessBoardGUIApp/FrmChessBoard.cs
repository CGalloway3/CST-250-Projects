/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */

using ChessBoardClassLibrary.Enums;
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;
using System.Windows.Forms;

namespace ChessBoardGUIApp
{
    public partial class FrmChessBoard : Form
    {
        // Class level variables
        private BoardModel _board;
        private BoardLogic _boardLogic;
        // 2D array of buttons for the chess board
        private Button[,] _buttons;
        private ChessPiece _newestPiece;
        private bool _panelHighlight = false;

        /// <summary>
        /// Default constructor for FrmChessBoard
        /// </summary>

        public FrmChessBoard()
        {
            InitializeComponent();

            // Initialize class level variables
            _board = new BoardModel(8);
            _boardLogic = new BoardLogic();
            _buttons = new Button[8, 8];
            cmbChessPieces.SelectedIndex = 0;
            cmbColor.SelectedIndex = 0;

            // Set up the panel with buttons
            SetUpButtons();

            // Draw the buttons in a proper checkerboard fashion
            RedrawButtonColors();
        }

        /// <summary>
        /// Populate the panel control with buttons
        /// </summary>
        private void SetUpButtons()
        {
            // Declare and initialize
            // Calculate the size of each button based on
            // the panel width and the number of buttons needed
            int buttonSize = pnlChessBoard.Width / _board.Size;
            // Set the panel to be square
            pnlChessBoard.Height = pnlChessBoard.Width;
            // Use nested for loops to loop through the boards Grid
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    // Set up each individual button
                    // Create a new button in the 2D array
                    _buttons[row, col] = new Button();
                    // Get the current button
                    Button button = _buttons[row, col];
                    // Set the size for the button
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    // Set the location of the button
                    // using the left and top sides
                    button.Top = row * buttonSize;  // Button Top and Left were backwards in the original activity sheet so I swapped
                    button.Left = col * buttonSize; // their positions now the rows and columns display properly on the buttons
                    // Attach a click event handler to the button
                    button.Click += BtnSquareClickEH;
                    // Store the location of the button in
                    // the Tag property using a Point object
                    button.Tag = new Point(row, col);
                    // Set the text for the button and its color to that of a black piece by default
                    button.ForeColor = _board.BlackPieceColorValue;
                    // button.Text = $"{row}, {col}"; // Commented out to clean up the initial load state but left in for possible debugging later if needed.               
                    // Add the button to the panels controls
                    pnlChessBoard.Controls.Add(_buttons[row, col]);
                }
            }
        }// End of SetUpButtons method

        /// <summary>
        /// Update the text for each button based on the board
        /// </summary>
        private void UpdateButtons()
        {
            // Loop through each cell in the grid to update the corresponding button
            for (int row = 0; row < _board.Size; ++row)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    if (_board.Grid[row, col].PieceOccupyingCell.Type != PieceType.None)
                    {
                        // Update the text for the button
                        _buttons[row, col].Text = _board.Grid[row, col].PieceOccupyingCell.Type.ToString();
                    }
                    else if (_board.Grid[row, col].IsLegalNextMove)
                    {
                        // Set the text to show a legal move
                        _buttons[row, col].Text = "Legal Move";
                    }
                    else
                    {
                        // Clear the text for any other buttons
                        _buttons[row, col].Text = "";
                    }
                }
            } // End of UpdateButtons method
        }



        /// <summary>
        /// Click Event Handler for the chess board buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSquareClickEH(object sender, EventArgs e)
        {
            // Declare and initialize
            PieceType pieceType;
            Button button = (Button)sender;
            Point point = (Point)button.Tag;
            int row = point.X;
            int col = point.Y;
            
            // Find the piece type and handle cases out of bounds
            try
            {
                pieceType = (PieceType)Enum.Parse(typeof(PieceType), cmbChessPieces.Text);
            }
            catch (Exception ex) 
            {
                pieceType = PieceType.None;
            }
            PieceColor pieceColor = (PieceColor)Enum.Parse(typeof(PieceColor), cmbColor.Text);

            // Show the user their choice
            MessageBox.Show(this, $"You clicked on row {row} and column {col}. \n     To place a {pieceColor} {pieceType}.");
            // Send the board, current cell, and piece to the business logic layer to place the piece and mark its legal moves given the boards current state
            _newestPiece = new ChessPiece(pieceType, pieceColor);
            _board = _boardLogic.MarkLegalMoves(_board, _board.Grid[row, col], _newestPiece);

            // Update the buttons to reflect the boards state
            UpdateButtons();
            // Ensure the buttons are colored properly
            RedrawButtonColors();
        }

        /// <summary>
        /// Change the color of the piece one (black) pieces.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPieceOneColorClickEH(object sender, EventArgs e)
        {
            // Show the dialog
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the black pieces color
                _board.BlackPieceColorValue = colorDialog.Color;
            }

            RedrawButtonColors();
            ResetCustomGroupBoxColors();
        }

        /// <summary>
        /// Change the color of the piece two (white) pieces.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPieceTwoColorClickEH(object sender, EventArgs e)
        {
            // Show the dialog
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the black pieces color
                _board.WhitePieceColorValue = colorDialog.Color;
            }

            RedrawButtonColors();
            ResetCustomGroupBoxColors();
        }

        /// <summary>
        /// Change the color of the white board squares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCustom1ClickEH(object sender, EventArgs e)
        {
            // Show the dialog
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the black pieces color
                _board.WhiteSquareColorValue = colorDialog.Color;
            }

            RedrawButtonColors();
            ResetCustomGroupBoxColors();
        }

        /// <summary>
        /// Change the color of the black board squares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCustom2ClickEH(object sender, EventArgs e)
        {
            // Show the dialog
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the black pieces color
                _board.BlackSquareColorValue = colorDialog.Color;
            }

            RedrawButtonColors();
            ResetCustomGroupBoxColors();
        }

        /// <summary>
        /// Set the board with the palette one color scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPalette1ClickEH(object sender, EventArgs e)
        {
            SetBoardColors(btnPalette1_1, btnPalette1_3);
        }


        /// <summary>
        /// Set the board with the palette two color scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPalette2ClickEH(object sender, EventArgs e)
        {
            SetBoardColors(btnPalette2_1, btnPalette2_3);
        }

        /// <summary>
        /// Set the board with the palette three color scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPalette3ClickEH(object sender, EventArgs e)
        {
            SetBoardColors(btnPalette3_1, btnPalette3_3);
        }

        /// <summary>
        /// Set the board with the palette four color scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPalette4ClickEH(object sender, EventArgs e)
        {
            SetBoardColors(btnPalette4_1, btnPalette4_3);
        }

        /// <summary>
        /// Set the board with the palette five color scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPalette5ClickEH(object sender, EventArgs e)
        {
            SetBoardColors(btnPalette5_1, btnPalette5_3);
        }

        /// <summary>
        /// Set the board with the palette six color scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPalette6ClickEH(object sender, EventArgs e)
        {
            SetBoardColors(btnPalette6_1, btnPalette6_3);
        }

        /// <summary>
        /// Set the boards colors via the passed in params of the two buttons
        /// </summary>
        /// <param name="blackPiece_WhiteSquareButton"></param>
        /// <param name="whitePiece_BlackSquareButton"></param>
        private void SetBoardColors(Button blackPiece_WhiteSquareButton,  Button whitePiece_BlackSquareButton)
        {
            _board.BlackPieceColorValue = blackPiece_WhiteSquareButton.ForeColor;
            _board.WhitePieceColorValue = whitePiece_BlackSquareButton.ForeColor;
            _board.BlackSquareColorValue = whitePiece_BlackSquareButton.BackColor;
            _board.WhiteSquareColorValue = blackPiece_WhiteSquareButton.BackColor;

            RedrawButtonColors();
            ResetCustomGroupBoxColors();
        }

        /// <summary>
        /// Method for drawing the boards checker pattern colors
        /// </summary>
        private void RedrawButtonColors()
        {
            // Loop through all the squares(buttons) on the chess board
            foreach (Button button in _buttons)
            {
                // Record the board coordinate location for the found square(button)
                Point loc = (Point)button.Tag;
                int row = loc.X;
                int col = loc.Y;

                // Paint the proper color on the square using mod to do an even odd comparison on the x, y sum
                if ((row + col) % 2 == 0)
                {
                    button.BackColor = _board.WhiteSquareColorValue;
                }
                else
                {
                    button.BackColor = _board.BlackSquareColorValue;
                }

                // If the square has a piece on it paint that piece
                if (_board.Grid[row, col].PieceOccupyingCell.Color == PieceColor.White)
                {
                    button.ForeColor = _board.WhitePieceColorValue;
                }
                else
                {
                    button.ForeColor = _board.BlackPieceColorValue;
                }

                // If the square is marked as a legal move for the current piece paint it
                if (button.Text == "Legal Move")
                {
                    if (_newestPiece.Color == PieceColor.White)
                    {
                        button.ForeColor = _board.WhitePieceColorValue;
                    }
                    else
                    {
                        button.ForeColor = _board.BlackPieceColorValue;
                    }

                    // highlight legal moves
                    button.BackColor = Color.LightYellow;
                }
            }
        }

        /// <summary>
        /// Reset the colors of the custom colors group box buttons
        /// </summary>
        private void ResetCustomGroupBoxColors()
        {
            // Set forecolors
            btnCustom1.ForeColor = _board.BlackPieceColorValue;
            btnCustom2.ForeColor = _board.BlackPieceColorValue;
            btnCustom3.ForeColor = _board.WhitePieceColorValue;
            btnCustom4.ForeColor = _board.WhitePieceColorValue;

            //set backcolors
            btnCustom1.BackColor = _board.WhiteSquareColorValue;
            btnCustom2.BackColor = _board.BlackSquareColorValue;
            btnCustom3.BackColor = _board.BlackSquareColorValue;
            btnCustom4.BackColor = _board.WhiteSquareColorValue;

            // Set the piece button fore colors
            btnCustomWhite.ForeColor = _board.WhitePieceColorValue;
            btnCustomBlack.ForeColor = _board.BlackPieceColorValue;
        }

        /// <summary>
        /// Method for catching mouse entry on a panels buttons so we can paint a border on the panel the button is in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPaletteMouseEnterEH(object sender, EventArgs e)
        {
            ((Control)sender).Parent.Invalidate(); // Force panel repaint
            _panelHighlight = true;
        }

        /// <summary>
        /// Method for catching mouse exit on a panels buttons so we can remove the panels border
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPaletteMouseLeaveEH(object sender, EventArgs e)
        {
            ((Control)sender).Parent.Invalidate(); // Force panel repaint
            _panelHighlight = false;
        }

        /// <summary>
        /// Method to determine if a panel boarder is to be applied and apply it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void PnlPalettePaintEH(object sender, PaintEventArgs e)
        {
            var panel = (Panel)sender;
            // if flagged for highlighting do it.
            if (_panelHighlight)
            {
                using (Pen p = new Pen(Color.DarkCyan, 2))
                {
                    e.Graphics.DrawRectangle(p, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }            
    }
}
