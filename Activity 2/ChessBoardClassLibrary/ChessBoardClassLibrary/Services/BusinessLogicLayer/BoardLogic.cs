/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References: ChatGPT and Gemini were consulted heavily on the MarkValidSlidingPieceMoves method. I was originally manually 
 *             tracking every possible move in each direction and I didn't like that approach. I knew there had to be something 
 *             simpler that I just wasn't seeing. The AI models suggested using a direction vector and a multiplication step 
 *             counter to make things easier. I just needed to create an array of vectors using tuples. The implementation allowed 
 *             me to turn several different methods that tracked multiple different directions into a much simpler singular direction 
 *             tracking method for all the sliding pieces. Once I had this initial method laid out I used what I learn there 
 *             to write the non sliding and pawn methods.
 */

using ChessBoardClassLibrary.Enums;
using ChessBoardClassLibrary.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ChessBoardClassLibrary.Services.BusinessLogicLayer
{
    public class BoardLogic
    {
        /// <summary>
        /// Reset the board by setting the
        /// cell properties back to default
        /// Encapsulate this method so it can only be
        /// called from this class.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private BoardModel ResetBoard(BoardModel board)
        {
            // Use a foreach loop to iterate over every cell
            foreach (CellModel cell in board.Grid)
            {
                // Set the properties to their defaults
                cell.IsLegalNextMove = false;
                cell.PieceOccupyingCell = new ChessPiece(); // Fills cell with a ChessPiece of type PieceType.None
            }
            // Return the board back to the presentation layer
            return board;
        }

        /// <summary>
        /// Method to leave the pieces in place and clear only the legal moves ResetBoard is too harsh in some cases.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private BoardModel ClearLegalMoves(BoardModel board)
        {
            foreach (CellModel cell in board.Grid)
            {
                cell.IsLegalNextMove = false;
            }
            // Return the board cleared of all legal moves
            return board;
        }

        /// <summary>
        /// Check if a row/column location is on the board
        /// Encapsulate this method so it can only be
        /// called from this class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            // Get the size of the board
            int size = board.Size;
            // Check if the row is on the board
            bool IsRowSafe = row >= 0 && row < size;
            // Check if the column is on the board
            bool IsColumnSafe = col >= 0 && col < size;
            // Return true if both row and column are safe
            return IsRowSafe && IsColumnSafe;
        }

        public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, string piece)
        {
            ChessPiece chessPiece = new ChessPiece(piece);
            return MarkLegalMoves(board, currentCell, chessPiece.Type, chessPiece.Color);
        }
        
        /// <summary>
        /// Mark the legal moves for the given piece and location
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <returns> A board object with the valid moves marked for a piece of the type and color
        /// passed at the passed cell location in the board grid.</returns>
        /// <remarks>Passing in a board with pieces on it already may not be the best idea with this
        /// implementation. I may alter it slightly later depending on the UI implementation. 
        /// I am envisioning this method as a way to make a highlighting overlay type board for 
        /// displaying legal moves dependent on the pieces the user picks to move.
        /// For example in a console this method may lay the groundwork to change background or foreground
        /// colors of console texts elements to signify legal moves.</remarks>
        public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, PieceType type, PieceColor color)
        {
            // Reset the board
            board = ClearLegalMoves(board);
            // Place the piece
            board.Grid[currentCell.Row, currentCell.Col].PieceOccupyingCell = new ChessPiece(type, color);

            // Use a switch statement to determine the behavior of the piece
            switch (type)
            {
                case PieceType.Knight:
                    // Set the moves for the Knight piece
                    var knightMoves = new (int, int)[] { (2, 1), (2, -1), (-2, 1), (-2, -1), (-1, 2), (1, 2), (-1, -2), (1, -2) };
                    // Mark the valid moves for the Knight
                    board = MarkValidNonSlidingPieceMoves(board, currentCell, knightMoves);
                    break;

                case PieceType.Rook:
                    // Set the movement directions for the Rook piece
                    var rookDirections = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
                    // Mark the valid moves for Rook
                    board = MarkValidSlidingPieceMoves(board, currentCell, rookDirections);
                    break;

                case PieceType.Bishop:
                    // Set the movement directions for the Bishop piece
                    var bishopDirections = new (int, int)[] { (-1, -1), (1, 1), (1, -1), (-1, 1) };
                    // Mark the valid moves for Bishop
                    board = MarkValidSlidingPieceMoves(board, currentCell, bishopDirections);
                    break;

                case PieceType.Queen:
                    // Set the movement directions for the Queen piece
                    var queenDirections = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (1, 1), (1, -1), (-1, 1) };
                    // Mark the valid moves for Queen
                    board = MarkValidSlidingPieceMoves(board, currentCell, queenDirections);
                    break;

                case PieceType.King:
                    // Set the moves for the King piece
                    var kingMoves = new (int, int)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
                    // Mark the valid moves for King
                    board = MarkValidNonSlidingPieceMoves(board, currentCell, kingMoves);
                    break;

                case PieceType.Pawn:
                    // Mark the valid moves for pawn
                    board = MarkValidPawnMoves(board, currentCell);
                    break;

                default:
                    // If the piece is not valid, return the board as is
                    return board;
            }
            // Return the updated board
            return board;
        }
        // End of MarkLegalMoves method

        /// <summary>
        /// Marks all legal moves for a sliding chess piece (rook, bishop, queen)
        /// by iterating through the possible movement directions and identifying
        /// empty squares or capturable pieces until blocked.
        /// </summary>
        /// <param name="board">The current game board model.</param>
        /// <param name="currentCell">The cell containing the active piece we are testing.</param>
        /// <param name="directions">An array of direction vectors for movement.</param>
        /// <returns>The updated board with legal move flags applied. No Pieces are moved or altered.</returns>
        /// <remarks>
        /// The <see cref="PieceType.enPassant"/> piece is modeled as a 
        /// temporary, turn-limited “ghost” piece that only affects pawn movement.
        /// Sliding pieces treat en passant cells as empty spaces to maintain
        /// consistent traversal logic.
        /// </remarks>
        private BoardModel MarkValidSlidingPieceMoves(BoardModel board, CellModel currentCell, (int rowStepDelta, int colStepDelta)[] directions)
        {
            // Declare and Initialize variables for use in the loops.
            ChessPiece currentPiece = currentCell.PieceOccupyingCell;

            // For each possible slide direction (directions) loop through the deltas (rowStepDelta and colStepDelta) step by step.
            foreach (var (rowStepDelta, colStepDelta) in directions)
            {
                // Iterate through each of the delta steps in this direction
                for (int currentStep = 1; currentStep < board.Grid.GetLength(0); currentStep++)
                {
                    // Calculate the coordinates of the next cell in this direction
                    int targetRow = currentCell.Row + rowStepDelta * currentStep;
                    int targetCol = currentCell.Col + colStepDelta * currentStep;

                    // If the cell is not on the board we have slide off the board and we can break out of this direction.
                    if (!IsOnBoard(board, targetRow, targetCol))
                    {
                        break;
                    }

                    // We have determined we are on the board, set some values for the target cell and the target pieces
                    CellModel targetCell = board.Grid[targetRow, targetCol];
                    ChessPiece targetPiece = targetCell.PieceOccupyingCell;

                    // Determine whether this movement path is blocked by a piece (en passant pieces are invisible to these movers)
                    if (targetPiece.Type == PieceType.None || targetPiece.Type == PieceType.EnPassant)
                    {
                        // The cell has no pieces we will mark it as a legal move and continue the slide loop
                        targetCell.IsLegalNextMove = true;
                        continue;
                    }

                    // Reaching this point in the method signifies we have hit a pieces
                    // Determine if it is our piece or an enemy piece
                    if (currentPiece.Color != targetPiece.Color)
                    {
                        targetCell.IsLegalNextMove = true; // We hit an enemy piece it is a legal move
                    }
                    // Implied else, The piece we encountered was our own so no legal move was marked.
                    // We will break after hitting the piece regardless of the result because our slide is complete in this direction
                    break;                    
                }
            }
            return board;
        }

        /// <summary>
        /// Mark the valid moves for all the pieces that don't slide (king, knight)
        /// Access modifier is private - meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board">The current game board model.</param>
        /// <param name="currentCell">The cell containing the active piece we are testing.</param>
        /// <param name="moves">An array of movement offsets that are the pieces possible legal moves</param>
        /// <returns>The updated board with legal move flags applied. No Pieces are moved or altered.</returns>
        /// <remarks>
        /// The <see cref="PieceType.enPassant"/> piece is modeled as a 
        /// temporary, turn-limited “ghost” piece that only affects pawn movement.
        /// Non-Sliding pieces treat en passant cells as empty spaces to maintain
        /// consistent traversal logic.
        /// </remarks>
        private BoardModel MarkValidNonSlidingPieceMoves(BoardModel board, CellModel currentCell, (int rowOffset, int colOffset)[] moves)
        {
            foreach (var (rowOffset, colOffset) in moves)
            {
                // Calculate the coordinates of the next possible move
                int targetRow = currentCell.Row + rowOffset;
                int targetCol = currentCell.Col + colOffset;

                // Determine if the cell is on the board.
                if (!IsOnBoard(board, targetRow, targetCol))
                {
                    continue; // Cell is off the board, continue to the next move location
                }

                // We have determined we are on the board, set some values for the target cell and the target pieces
                CellModel targetCell = board.Grid[targetRow, targetCol];
                ChessPiece targetPiece = targetCell.PieceOccupyingCell;

                // Target cell is on the board, Determine if a piece is located there (en passant pieces are invisible to these movers) or if it is an enemy piece.
                if (targetPiece.Type == PieceType.None || targetPiece.Type == PieceType.EnPassant || currentCell.PieceOccupyingCell.Color != targetPiece.Color)
                {
                    // The cell has no pieces or it has an enemy, we will mark it as a legal move and continue to the next move in moves
                    targetCell.IsLegalNextMove = true;
                }
                // Fall out the bottom to the next iteration not marking anything. This happens when we encounter our own piece.
            }
            return board;
        }

        /// <summary>
        /// Marks valid moves for a pawn
        /// Access modifier is private - meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board">The current game board model.</param>
        /// <param name="currentCell">The cell containing the active piece we are testing.</param>
        /// <returns>The updated board with legal move flags applied. No Pieces are moved or altered.</returns>
        /// <remarks>
        /// This method assumes that the black pieces start at the top of the board
        /// and the white pieces start at the bottom. If that is not the case in your UI
        /// then the pawn moves are coded incorrectly here. Reverse the white and black values
        /// in <see cref="PieceColor"/> to rectify this and make white the top color.
        /// 
        /// Note: PieceColor enum values are signed to represent board movement direction.
        /// White = -1 moves "up" the board, Black = 1 moves "down".
        /// This method enforces standard pawn movement rules, including:
        ///  - Forward single-step moves if unoccupied
        ///  - Double-step opening move from the start rank
        ///  - Diagonal captures of opposing pieces
        /// En passant and promotion are handled elsewhere in the move logic.
        /// </remarks>
        private BoardModel MarkValidPawnMoves(BoardModel board, CellModel currentCell)
        {
            // Declare and initialize
            ChessPiece currentPiece = currentCell.PieceOccupyingCell;

            // Handle single move ahead
            // 
            // Calculate the coordinates of one move straight ahead and set the target variables
            // We don't need to check for IsOnBoard because any piece that reaches the edge is converted to a queen
            int targetRow = currentCell.Row + (int)currentPiece.Color;
            int targetCol = currentCell.Col;
            CellModel targetCell = board.Grid[targetRow, targetCol];
            ChessPiece targetPiece = targetCell.PieceOccupyingCell;

            // Determine if the move one space straight ahead is clear
            if (targetPiece.Type == PieceType.None)
            {
                // Move is clear mark it as a legal move
                targetCell.IsLegalNextMove = true;
            }

            // Handle double move from start position
            //
            // Determine if a double move is valid given all the cases
            if (IsOnBoard(board, targetRow + (int)currentPiece.Color, targetCol) // case 1 cell we are checking is actually on the board.
                && targetCell.IsLegalNextMove // case 2 can we 'slide' past this spot because it is a legal move
                && (currentCell.Row == 1 || currentCell.Row == 6) // case 3: ensure pawn is on its start rank; IsOnBoard ensures this is for the correct side.
                && board.Grid[targetRow + (int)currentPiece.Color, targetCol].PieceOccupyingCell.Type == PieceType.None) // case 4 the spot where we want to end up is empty also
            {
                // Spot is empty and clear to slide in from our start row
                board.Grid[targetRow + (int)currentPiece.Color, targetCol].IsLegalNextMove = true;
            }

            // Handle diagonal capture
            //
            // Set capture moves to a variable for pawns
            var pawnCaptures = new (int, int)[] { ((int)currentPiece.Color, 1), ((int)currentPiece.Color, -1) };
            // Iterate over capture moves
            foreach (var (rowOffset, colOffset) in pawnCaptures)
            {
                // Calculate the coordinates of the possible capture
                targetRow = currentCell.Row + rowOffset;
                targetCol = currentCell.Col + colOffset;

                // Determine if the cell is on the board.
                if (!IsOnBoard(board, targetRow, targetCol))
                {
                    continue; // Cell is off the board, continue to the next move location
                }

                // We are on the board set target variable values
                targetCell = board.Grid[targetRow, targetCol];
                targetPiece = targetCell.PieceOccupyingCell;

                // Determine if a piece is present and it is an enemy
                if (targetPiece.Type != PieceType.None && targetPiece.Color != currentPiece.Color)
                {
                    // There is an enemy piece available for capture
                    targetCell.IsLegalNextMove = true;
                }
            }
            return board;
        }
    }
}
