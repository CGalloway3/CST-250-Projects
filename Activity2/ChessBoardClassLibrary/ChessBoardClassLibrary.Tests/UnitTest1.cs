/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */

using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

namespace ChessBoardClassLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void MarkValidKnightMoves_MarksProperMoves()
        {
            // Arrange
            BoardLogic boardLogic = new BoardLogic();
            BoardModel board = new BoardModel(8);

            // Act
            board = boardLogic.MarkLegalMoves(board, board.Grid[2,7], Enums.PieceType.Knight, Enums.PieceColor.White);

            // Assert
            Assert.NotNull(board);
            Assert.True(board.Grid[4, 6].IsLegalNextMove);
            Assert.True(board.Grid[0, 6].IsLegalNextMove);
        }

        [Fact]
        public void MarkValidRookMoves_MarksProperMoves()
        {
            // Arrange
            BoardLogic boardLogic = new BoardLogic(); //Initiate the logic
            BoardModel board = new BoardModel(8); // Initialize the board as blank
            board.Grid[7, 2].PieceOccupyingCell = new ChessPiece(Enums.PieceType.Pawn, Enums.PieceColor.Black); // add a piece of the opposite color in the way

            // Act: Call board logic mark legal moves on the board for a rook at 7,5
            board = boardLogic.MarkLegalMoves(board, board.Grid[7, 5], Enums.PieceType.Rook, Enums.PieceColor.White); 

            // Assert
            Assert.NotNull(board);
            Assert.True(board.Grid[6, 5].IsLegalNextMove);
            Assert.True(board.Grid[7, 2].IsLegalNextMove);
            Assert.False(board.Grid[7, 1].IsLegalNextMove);
        }

        [Fact]
        public void MarkValidKingMoves_MarksProperMoves()
        {
            // Arrange
            BoardLogic boardLogic = new BoardLogic();
            BoardModel board = new BoardModel(8);

            // Act 
            board = boardLogic.MarkLegalMoves(board, board.Grid[4, 7], Enums.PieceType.King, Enums.PieceColor.White);

            // Assert
            Assert.NotNull(board);
            Assert.True(board.Grid[4, 6].IsLegalNextMove);
            Assert.False(board.Grid[4, 5].IsLegalNextMove);
        }
    }
}
