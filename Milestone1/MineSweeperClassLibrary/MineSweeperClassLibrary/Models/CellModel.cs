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
    public class CellModel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public CellVisualStates VisualState { get; set; }
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlagged { get; set; }
        public int NumberOfBombNeighbors { get; set; }
        public bool HasSpecialReward { get; set; }

        public CellModel()
        {
            Row = -1;
            Column = -1;
            VisualState = CellVisualStates.Hidden;
            IsVisited = false;
            IsBomb = false;
            IsFlagged = false;
            NumberOfBombNeighbors = 0;
            HasSpecialReward = false;
        }

    }
}
