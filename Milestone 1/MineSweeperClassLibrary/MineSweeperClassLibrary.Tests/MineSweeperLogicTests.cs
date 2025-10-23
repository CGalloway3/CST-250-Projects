/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

using MineSweeperClassLibrary.Models;

namespace MineSweeperClassLibrary.Tests
{
    public class MineSweeperLogicTests
    {
        // Test proper initialization of the board matrix
        [Fact]
        public void BoardModelConstructor_CreatesProperSizeMatrix()
        {
            // Arrange: Create an instance of the BoardModel with specific dimensions
            int size = 10; 
            BoardModel board = new BoardModel(size);

            // Act & Assert: Verify that the Cells property is initialized correctly and contains the proper count in all cases.
            Assert.NotNull(board.Cells);
            Assert.Equal(size, board.Size);
            Assert.Equal(size, board.Cells.GetLength(0)); // Rows
            Assert.Equal(size, board.Cells.GetLength(1)); // Columns
            Assert.Equal(size * size, board.Cells.Length); // Total cells
        }
    }
}
