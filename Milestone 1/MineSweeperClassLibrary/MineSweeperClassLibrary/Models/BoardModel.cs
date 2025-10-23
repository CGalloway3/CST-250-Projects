/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

namespace MineSweeperClassLibrary.Models
{
    public class BoardModel
    {
        public int Size { get; set; }
        public CellModel[,] Cells { get; set; }

        public BoardModel(int size)
        {
            Size = size;
            Cells = new CellModel[size, size];
        }
    }
}
