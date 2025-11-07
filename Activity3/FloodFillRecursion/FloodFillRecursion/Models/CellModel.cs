/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Flood Fill Recursion
 * Activity 3 Part 4
 * References:
 */

namespace FloodFillRecursion.Models
{
    internal class CellModel
    {
        // Cell Model Properties
        public int Row { get; set; }
        public int Col { get; set; }
        public string Contents { get; set; }

        /// <summary>
        /// Parameterized constructor for CellModel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="contents"></param>
        public CellModel(int row, int col, string contents)
        {
            Row = row;
            Col = col;
            Contents = contents;
        }
    }
}
