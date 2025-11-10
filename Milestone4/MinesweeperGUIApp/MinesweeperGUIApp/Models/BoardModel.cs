/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

using MinesweeperGUIApp.Models.Enums;

namespace MinesweeperGUIApp.Models
{
    public class BoardModel
    {
        // Public class level variables
        public int Size { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public CellModel[,] Cells { get; set; }
        public int Difficulty { get; set; } = 1;
        public int NumberOfBombs { get; set; }
        public int RewardsRemaining { get; set; } = 0;
        public GameState GameState { get; set; } = GameState.InProgress;

        /// <summary>
        /// Public Model constructor
        /// </summary>
        /// <param name="size"></param>
        public BoardModel(int size)
        {
            // Initialize variables
            Size = size;
            Cells = new CellModel[size, size];

            // Initialize the board matrix with CellModel instances
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Cells[row, col] = new CellModel
                    {
                        Row = row,
                        Column = col
                    };
                }
            }
        }
    }
}
