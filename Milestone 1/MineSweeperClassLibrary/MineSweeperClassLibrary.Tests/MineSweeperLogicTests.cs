/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

using MineSweeperClassLibrary.Models;
using MineSweeperClassLibrary.BusinessLogicLayer;
using MineSweeperClassLibrary.Enums;
using Xunit;

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

        // Test proper initialization of a cell
        [Fact]
        public void CellModel_DefaultConstructor_InitializesProperties()
        {
            // Arrange & Act: Create an instance of the CellModel
            CellModel cell = new CellModel();

            // Assert: Verify that the properties are initialized to their default values
            Assert.NotNull(cell);
            Assert.Equal(-1, cell.Row);
            Assert.Equal(-1, cell.Column);
            Assert.Equal(CellVisualStates.Hidden, cell.VisualState);
            Assert.False(cell.IsVisited);
            Assert.False(cell.IsBomb);
            Assert.False(cell.IsFlagged);
            Assert.Equal(0, cell.NumberOfBombNeighbors);
            Assert.False(cell.HasSpecialReward);
        }

        // BoardLogic constructor successfully creates an instance of the board model
        [Fact]
        public void BoardLogic_Constructor_CreatesBoardModelInstance()
        {
            // Arrange: Create an instance of the BoardLogic with a specific size
            int size = 10;
            BoardLogic boardLogic = new BoardLogic(size);

            // Use reflection to access the private _board field // This part written by the auto complete feature of Visual Studio. I understand what it is doing but I could not have written it myself.
            var boardField = typeof(MineSweeperClassLibrary.BusinessLogicLayer.BoardLogic)
                .GetField("_board", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var boardModel = boardField.GetValue(boardLogic) as BoardModel;

            // Assert: Verify that the boardLogic and the _board field containing the BoardModel is initialized correctly
            Assert.NotNull(boardLogic);
            Assert.NotNull(boardModel);
            Assert.NotNull(boardModel.Cells);
            Assert.Equal(size, boardModel.Size);
            Assert.Equal(size * size, boardModel.Cells.Length);
        }

        // BoardLogic.SetupBombs successfully places bombs on the board at difficulty 1 10% bombs
        [Fact]
        public void BoardLogic_SetupBombs_Difficulty1_SetsCorrectNumberOfBombs()
        {
            // Arrange: Create an instance of the BoardLogic with a specific size and set difficulty
            int size = 10;
            BoardLogic boardLogic = new BoardLogic(size);

            // Use reflection to access the private _board field. Exact same code block as above to gain access to the private BoardModel instance of _board.
            var boardField = typeof(MineSweeperClassLibrary.BusinessLogicLayer.BoardLogic)
                .GetField("_board", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var boardModel = boardField.GetValue(boardLogic) as BoardModel;

            // Act: Set difficulty and call SetupBombs
            boardModel.Difficulty = 1; // 10% bombs
            boardLogic.SetupBombs();

            

            // Assert: Verify that the correct number of bombs are placed
            int expectedBombs = (int)(size * size * 0.10); // 10% of total cells
            Assert.Equal(expectedBombs, boardModel.NumberOfBombs);
        }

        // BoardLogic.SetupBombs successfully places bombs on the board at difficulty 2 15% bombs
        [Fact]
        public void BoardLogic_SetupBombs_Difficulty2_SetsCorrectNumberOfBombs()
        {
            // Arrange: Create an instance of the BoardLogic with a specific size and set difficulty
            int size = 10;
            BoardLogic boardLogic = new BoardLogic(size);

            // Use reflection to access the private _board field. Exact same code block as above to gain access to the private BoardModel instance of _board.
            var boardField = typeof(MineSweeperClassLibrary.BusinessLogicLayer.BoardLogic)
                .GetField("_board", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var boardModel = boardField.GetValue(boardLogic) as BoardModel;

            // Act: Set difficulty and call SetupBombs
            boardModel.Difficulty = 2; // 15% bombs
            boardLogic.SetupBombs();

            // Assert: Verify that the correct number of bombs are placed
            int expectedBombs = (int)(size * size * 0.15); // 15% of total cells
            Assert.Equal(expectedBombs, boardModel.NumberOfBombs);
        }

        // BoardLogic.SetupBombs successfully places bombs on the board at difficulty 3 25% bombs
        [Fact]
        public void BoardLogic_SetupBombs_Difficulty3_SetsCorrectNumberOfBombs()
        {
            // Arrange: Create an instance of the BoardLogic with a specific size and set difficulty
            int size = 10;
            BoardLogic boardLogic = new BoardLogic(size);

            // Use reflection to access the private _board field. Exact same code block as above to gain access to the private BoardModel instance of _board.
            var boardField = typeof(MineSweeperClassLibrary.BusinessLogicLayer.BoardLogic)
                .GetField("_board", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var boardModel = boardField.GetValue(boardLogic) as BoardModel;

            // Act: Set difficulty and call SetupBombs
            boardModel.Difficulty = 3; // 25% bombs
            boardLogic.SetupBombs();

            // Assert: Verify that the correct number of bombs are placed
            int expectedBombs = (int)(size * size * 0.25); // 15% of total cells
            Assert.Equal(expectedBombs, boardModel.NumberOfBombs);
        }

        // Verify CountBombsNearby() works correctly
        [Fact]
        public void BoardLogic_CountBombsNearby_SetsCorrectNeighborCounts()
        {
            // Arrange: Create an instance of the BoardLogic with a size of 5
            int size = 5;
            BoardLogic boardLogic = new BoardLogic(size);

            // Use reflection to access the private _board field. Exact same code block as above to gain access to the private BoardModel instance of _board.
            var boardField = typeof(MineSweeperClassLibrary.BusinessLogicLayer.BoardLogic)
                .GetField("_board", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var boardModel = boardField.GetValue(boardLogic) as BoardModel;

            // Manually place bombs for controlled testing
            boardModel.Cells[1, 1].IsBomb = true;
            boardModel.Cells[2, 2].IsBomb = true;
            boardModel.Cells[3, 3].IsBomb = true;

            // Act: Call CountBombsNearby
            boardLogic.CountBombsNearby();

            // Assert: Verify that the neighbor counts are correct
            Assert.Equal(1, boardModel.Cells[0, 0].NumberOfBombNeighbors); // Adjacent to (1,1)
            Assert.Equal(2, boardModel.Cells[1, 2].NumberOfBombNeighbors); // Adjacent to (1,1) and (2,2)
            Assert.Equal(2, boardModel.Cells[2, 1].NumberOfBombNeighbors); // Adjacent to (1,1) and (2,2)
            Assert.Equal(2, boardModel.Cells[2, 3].NumberOfBombNeighbors); // Adjacent to (2,2) and (3,3)
            Assert.Equal(1, boardModel.Cells[4, 4].NumberOfBombNeighbors); // Adjacent to (3,3)
            Assert.Equal(0, boardModel.Cells[0, 4].NumberOfBombNeighbors); // No adjacent bombs
        }
    }
}
