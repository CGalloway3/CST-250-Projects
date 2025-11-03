/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */


using System.Drawing;

namespace ChessBoardClassLibrary.Models
{
    public class BoardModel
    {
        // Class level properties
        // 'get' is public so other classes can read it.
        // 'private set' ensure only this class can modify it.
        // This is an example of encapsulation: internal details are hidden and controlled.
        public int Size { get; private set; }
        public CellModel[,] Grid { get; private set; }

        // Provides functionality to color the boards squares
        public Color BlackSquareColorValue { get; set; } = Color.Black;
        public Color WhiteSquareColorValue { get; set; } = Color.White;

        // Provides Functionality to color the boards pieces
        public Color BlackPieceColorValue { get; set; } = Color.DodgerBlue;
        public Color WhitePieceColorValue { get; set; } = Color.Fuchsia;

        /// <summary>
        /// Parameterized Constructor for BoardModel
        /// </summary>
        /// <param name="size"></param>
        public BoardModel(int size)
        {
            // Initialize the properties for the model
            Size = size;
            Grid = new CellModel[Size, Size];

            // Create the board
            InitializeBoard();
        }

        /// <summary>
        /// Set up a new board
        /// Encapsulate this helper method by making the access modifier private
        ///    so only the constructor can access this method.
        /// </summary>
        private void InitializeBoard()
        {
            // Loop through the rows of the grid
            for (int row = 0; row < Size; row++)
            {
                // Loop through the columns
                for (int col = 0; col < Size; col++)
                {
                    // Set each index to a new CellModel
                    // using the row and column
                    Grid[row, col] = new CellModel(row, col);
                }
            }

        }
    }
}
