/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */

namespace ChessBoardClassLibrary.Models
{
    public class CellModel
    {
        // Class level properties with public getters and private setters.
        // This is an example of encapsulation: external code can read the values.
        // but only this class can modify them.
        public int Row { get; private set; }
        public int Col { get; private set; }

        // These properties need to be both readable and writable from outside the model,
        // so we use public getters and setters. This is appropriate for properties
        // where external components (e.g., the board logic) are responsible for updating them.
        public string PieceOccupyingCell { get; set; }
        public bool IsLegalNextMove { get; set; }

        /// <summary>
        /// Parameterized constructor for cell model class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public CellModel(int row, int col)
        {
            Row = row;
            Col = col;
            // Set default values for the other properties
            PieceOccupyingCell = "";
            IsLegalNextMove = false;
        }
    }
}
