/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

using MineSweeperClassLibrary.Enums;

namespace MineSweeperClassLibrary.Models
{
    public class BoardModel
    {
        public int Size { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public CellModel[,] Cells { get; set; }
        public int Difficulty { get; set; } = 1;
        public int NumberOfBombs { get; set; }
        public int RewardsRemaining { get; set; } = 0;
        public GameStates GameState { get; set; } = GameStates.InProgress;

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
