/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 12/07/2025
 * Mine Sweeper Class Library
 * Milestone 6
 * References:
 */

using MinesweeperClassLibrary.Models.Enums;

namespace MinesweeperClassLibrary.Models
{
    /// <summary>
    /// Represents a cell in a grid-based game, such as Minesweeper, with properties to track its state and attributes.
    /// </summary>
    /// <remarks>This class provides properties to define the position of the cell, its state (e.g., visited,
    /// flagged), and additional attributes such as whether it contains a bomb, the number of neighboring bombs, and
    /// whether it has a special reward. It is designed to be used in grid-based games where cells have specific
    /// behaviors and interactions.</remarks>
    public class CellModel
    {
        // Public class level variables
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlagged { get; set; }
        public int NumberOfBombNeighbors { get; set; }
        public bool HasSpecialReward { get; set; }

        /// <summary>
        /// Public cell model constructor
        /// </summary>
        public CellModel()
        {
            Row = -1;
            Column = -1;
            IsVisited = false;
            IsBomb = false;
            IsFlagged = false;
            NumberOfBombNeighbors = 0;
            HasSpecialReward = false;
        }
    }
}
